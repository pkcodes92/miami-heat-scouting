// <copyright file="ScoutingReportController.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Controllers
{
    using API.Common.Models;
    using API.Common.Models.Input;
    using API.Common.Models.Response;
    using API.Data.Entities;
    using API.Services.Interfaces;
    using API.Validators;
    using FluentValidation.Results;
    using Microsoft.ApplicationInsights;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// This controller will have all the API methods for the <see cref="ScoutingReport"/> entity.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ScoutingReportController : ControllerBase
    {
        private readonly TelemetryClient telemetryClient;
        private readonly IScoutingReportService scoutingReportService;
        private readonly IUserService userService;
        private readonly IncomingScoutingReportValidator validator = new IncomingScoutingReportValidator();

        /// <summary>
        /// Initializes a new instance of the <see cref="ScoutingReportController"/> class.
        /// </summary>
        /// <param name="telemetryClient">The telemetry client injection.</param>
        /// <param name="scoutingReportService">The scouting report service injection.</param>
        /// <param name="userService">The user service injection.</param>
        public ScoutingReportController(
            TelemetryClient telemetryClient,
            IScoutingReportService scoutingReportService,
            IUserService userService)
        {
            this.telemetryClient = telemetryClient;
            this.scoutingReportService = scoutingReportService;
            this.userService = userService;
        }

        /// <summary>
        /// This will add a new scouting report to the database accordingly.
        /// </summary>
        /// <param name="newScoutingReport">The information required to add the new scouting report to the database.</param>
        /// <returns>A unit of execution that contains an action result.</returns>
        [HttpPost("AddNewScoutingReport")]
        public async Task<ActionResult> AddNewScoutingReportAsync(IncomingScoutingReport newScoutingReport)
        {
            InsertScoutingReportResponse apiResponse;

            var validationResult = this.validator.Validate(newScoutingReport);

            if (!validationResult.IsValid)
            {
                var validationList = this.BuildValidationErrors(validationResult);

                var apiErrorResponse = new InsertScoutingReportResponse
                {
                    ScoutingReportId = 0,
                    Success = false,
                    ValidationErrors = validationList,
                    Count = 0,
                };

                return this.Ok(apiErrorResponse);
            }

            try
            {
                var scoutingReportId = await this.scoutingReportService.InsertScoutingReportAsync(newScoutingReport);
                apiResponse = new InsertScoutingReportResponse
                {
                    ScoutingReportId = scoutingReportId,
                    Success = true,
                    ValidationErrors = null!,
                };
            }
            catch (Exception ex)
            {
                this.telemetryClient.TrackException(ex);
                apiResponse = new InsertScoutingReportResponse
                {
                    Success = false,
                    ScoutingReportId = 0,
                    Count = 0,
                    ValidationErrors = null!,
                };
            }

            return this.Ok(apiResponse);
        }

        /// <summary>
        /// This method will be returning all of the scouting reports in the database.
        /// </summary>
        /// <returns>A unit of execution that contains an HTTP result.</returns>
        [HttpGet("GetAllScoutingReports")]
        public async Task<ActionResult> GetAllScoutingReportsAsync()
        {
            GetAllScoutingReportsResponse apiResponse;

            var scoutingReports = await this.scoutingReportService.GetAllScoutingReportsAsync();

            apiResponse = new GetAllScoutingReportsResponse
            {
                ScoutingReports = scoutingReports,
                Count = scoutingReports.Count,
                Success = scoutingReports.Count > 0,
                ValidationErrors = null!,
            };

            return this.Ok(apiResponse);
        }

        /// <summary>
        /// This method gets the scouting reports that were done by the name of the scout.
        /// </summary>
        /// <param name="scoutName">The name of the scout.</param>
        /// <returns>A unit of execution that contains an HTTP result.</returns>
        [HttpGet("GetScoutingReports/{scoutName}")]
        public async Task<ActionResult> GetScoutingReportsByScoutAsync(string scoutName)
        {
            var scout = await this.userService.GetUserAsync(scoutName);

            var scoutingReports = await this.scoutingReportService.GetScoutingReportsByScoutAsync(scout.ScoutId);

            return this.Ok(scoutingReports);
        }

        private List<ValidationError> BuildValidationErrors(ValidationResult result)
        {
            var validationList = new List<ValidationError>();

            foreach (var item in result.Errors)
            {
                var validationItemToAdd = new ValidationError
                {
                    ErrorCode = item.ErrorCode,
                    Message = item.ErrorMessage,
                };

                validationList.Add(validationItemToAdd);
            }

            return validationList;
        }
    }
}
