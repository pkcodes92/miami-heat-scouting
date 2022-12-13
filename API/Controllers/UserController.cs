// <copyright file="UserController.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Controllers
{
    using API.Common.Models.Response;
    using API.Services.Interfaces;
    using Microsoft.ApplicationInsights;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// This is the controller to perform operations on the User entity.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly TelemetryClient telemetryClient;
        private readonly IUserService userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="telemetryClient">The application insights injection.</param>
        /// <param name="userService">The user service injection.</param>
        public UserController(TelemetryClient telemetryClient, IUserService userService)
        {
            this.telemetryClient = telemetryClient;
            this.userService = userService;
        }

        /// <summary>
        /// This method will retrieve all the users.
        /// </summary>
        /// <returns>A list of users.</returns>
        [HttpGet("GetAllUsers")]
        public async Task<ActionResult> GetAllUsersAsync()
        {
            GetAllUsersResponse apiResponse;

            try
            {
                var users = await this.userService.GetAllUsersAsync();

                apiResponse = new GetAllUsersResponse
                {
                    Users = users,
                    Success = true,
                    Count = users.Count,
                    ValidationErrors = null!,
                };
            }
            catch (Exception ex)
            {
                this.telemetryClient.TrackException(ex);
                apiResponse = new GetAllUsersResponse
                {
                    Users = null!,
                    Success = false,
                    Count = 0,
                    ValidationErrors = null!,
                };
            }

            return this.Ok(apiResponse);
        }

        /// <summary>
        /// This method gets all the active scouts (users) from the database.
        /// </summary>
        /// <returns>A list of all the active scouts.</returns>
        [HttpGet("GetAllActiveScouts")]
        public async Task<ActionResult> GetAllActiveScoutsAsync()
        {
            GetAllUsersResponse apiResponse;

            try
            {
                var users = await this.userService.GetAllActiveUsersAsync();

                apiResponse = new GetAllUsersResponse
                {
                    Count = users.Count,
                    Success = true,
                    Users = users,
                    ValidationErrors = null!,
                };
            }
            catch (Exception ex)
            {
                this.telemetryClient.TrackException(ex);
                apiResponse = new GetAllUsersResponse
                {
                    Users = null!,
                    Count = 0,
                    Success = false,
                    ValidationErrors = null!,
                };
            }

            return this.Ok(apiResponse);
        }
    }
}
