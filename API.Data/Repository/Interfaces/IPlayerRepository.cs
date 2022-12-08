using API.Data.Entities;

namespace API.Data.Repository.Interfaces
{
    public interface IPlayerRepository
    {
        /// <summary>
        /// This method definition will get a player by their first and last name.
        /// </summary>
        /// <param name="firstName">The player's first name</param>
        /// <param name="lastName">The player's last name.</param>
        /// <returns>A unit of execution containing the player being returned.</returns>
        Task<Player> GetPlayerByFirstAndLastNameAsync(string firstName, string lastName);
    }
}
