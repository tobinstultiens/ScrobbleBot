using System.Threading.Tasks;
using ScrobbleBot.Domain.Entities;

namespace ScrobbleBot.Application.Interfaces
{
    /// <summary>
    /// Represents the <see cref="ILastFmService"/> interface.
    /// </summary>
    public interface ILastFmService
    {
        /// <summary>
        /// Retrieves the profile information asynchronously.
        /// </summary>
        /// <param name="profileName">The profile name.</param>
        /// <returns>Returns an awaitable <see cref="Task{UserProfile}"/>.</returns>
        Task<UserProfile> GetProfileInfoAsync(string profileName);

        /// <summary>
        /// Retrieves the profile information asynchronously.
        /// </summary>
        /// <param name="artistName">The artist name.</param>
        /// <returns>Returns an awaitable <see cref="Task{ArtistProfile}"/>.</returns>
        Task<ArtistProfile> GetArtistInfoAsync(string artistName);
    }
}