using System.Threading.Tasks;
using ScrobbleBot.Domain.Entities;

namespace ScrobbleBot.Application.Interfaces
{
    /// <summary>
    /// This represents the <see cref="IUserService"/> interface.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Retrieves the user information asynchronously.
        /// </summary>
        /// <returns>The user information.</returns>
        Task<RestUser> GetUserAsync(string username);
        /// <summary>
        /// Set the user asynchronously
        /// </summary>
        /// <returns>true or false</returns>
        Task<bool> SetUserAsync(RestUser restUser);
        /// <summary>
        /// Update the user asynchronously
        /// </summary>
        /// <returns>true or false</returns>
        Task<bool> UpdateUserAsync(RestUser restUser);
        /// <summary>
        /// Deletes the user asynchronously
        /// </summary>
        /// <returns>true or false</returns>
        Task<bool> DeleteUserAsync(string username);
    }
}