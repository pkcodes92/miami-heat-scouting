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
    using Microsoft.ApplicationInsights;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// This controller will have all the API methods for the <see cref="ScoutingReport"/> entity.
    /// </summary>
    [ApiController]
    [Route("Scout")]
    public class ScoutingReportController : ControllerBase
    {
        private readonly TelemetryClient telemetryClient;
        private readonly IScoutingReportService scoutingReportService;
        private readonly IncomingScoutingReportValidator validator = new IncomingScoutingReportValidator();

        /// <summary>
        /// Initializes a new instance of the <see cref="ScoutingReportController"/> class.
        /// </summary>
        /// <param name="telemetryClient">The telemetry client injection.</param>
        /// <param name="scoutingReportService">The scouting report service injection.</param>
        public ScoutingReportController(TelemetryClient telemetryClient, IScoutingReportService scoutingReportService)
        {
            this.telemetryClient = telemetryClient;
            this.scoutingReportService = scoutingReportService;
        }

        /// <summary>
        /// This will add a new scouting report to the database accordingly.
        /// </summary>
        /// <param name="incomingScoutingReport">The information required to add the new scouting report to the database.</param>
        /// <returns>A unit of execution that contains an action result.</returns>
        [HttpPost]
        [Route("AddNewScoutingReport")]
        public async Task<ActionResult> AddNewScoutingReportAsync(IncomingScoutingReport incomingScoutingReport)
        {
            InsertScoutingReportResponse apiResponse;

            var validationResult = this.validator.Validate(incomingScoutingReport);

            if (!validationResult.IsValid)
            {
                var validationList = new List<ValidationError>();

                foreach (var item in validationResult.Errors)
                {
                    var validationItemToAdd = new ValidationError
                    {
                        ErrorCode = item.ErrorCode,
                        Message = item.ErrorMessage,
                    };

                    validationList.Add(validationItemToAdd);
                }

                _ = new InsertScoutingReportResponse
                {
                    ScoutingReportId = 0,
                    Success = false,
                    ValidationErrors = validationList,
                };
            }

            try
            {
                var scoutingReportId = await this.scoutingReportService.InsertScoutingReportAsync(incomingScoutingReport);
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
                };
            }

            return this.Ok(apiResponse);
        }

        /// <summary>
        /// This method will be returning all of the scouting reports in the database.
        /// </summary>
        /// <returns>A unit of execution that contains an HTTP result.</returns>
        [HttpGet]
        [Route("GetAllScoutingReports")]
        public async Task<ActionResult> GetAllScoutingReportsAsync()
        {
            return this.Ok();
        }
    }
}
