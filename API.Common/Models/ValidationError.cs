// <copyright file="ValidationError.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

#nullable disable

namespace API.Common.Models
{
    /// <summary>
    /// This class represents an error that is being returned by the API.
    /// </summary>
    public class ValidationError
    {
        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the necessary message.
        /// </summary>
        public string Message { get; set; }
    }
}
