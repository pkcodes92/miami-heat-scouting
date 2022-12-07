// <copyright file="ApiResponse.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Common.Models
{
    using Newtonsoft.Json;

    public class ApiResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether or not the response is successful.
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the necessary validation errors.
        /// </summary>
        [JsonProperty("errors")]
        public List<ValidationError> ValidationErrors { get; set; } = null!;
    }
}