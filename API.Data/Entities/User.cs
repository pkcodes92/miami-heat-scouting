// <copyright file="Scout.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Data.Entities
{
    /// <summary>
    /// This class represents the User entity.
    /// </summary>
    public partial class User
    {
        /// <summary>
        /// Gets or sets the Azure AD User Id.
        /// </summary>
        public string AzureAdUserId { get; set; } = null!;

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; } = null!;

        /// <summary>
        /// Gets or sets the date/time that the user has been created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the date/time that the user has been modified.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the user is active.
        /// </summary>
        public bool ActiveFlag { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        public int? Order { get; set; }
    }
}
