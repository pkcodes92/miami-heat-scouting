// <copyright file="Player.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Common.DTO
{
    /// <summary>
    /// This class represents the player being returned to the caller.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Gets or sets the player ID.
        /// </summary>
        public int PlayerId { get; set; }

        /// <summary>
        /// Gets or sets the first name of the player.
        /// </summary>
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the last name of the player.
        /// </summary>
        public string LastName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the birth date of the player.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// This method returns the full name of the player.
        /// </summary>
        /// <returns>The full name of the player.</returns>
        public string GetFullName()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
