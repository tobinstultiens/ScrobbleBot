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
        /// <returns>Returns an awaitable <see cref="Task{Artist}"/>.</returns>
        Task<ArtistProfile> GetArtistInfoAsync(string artistName);

        /// <summary>
        /// Retrieves the recently listened to tracks asynchronously.
        /// </summary>
        /// <param name="profileName">The profile name.</param>
        /// <returns>Returns an awaitable <see cref="Task{RecentTracks}"/>.</returns>
        Task<RecentTracks> GetRecentTracksAsync(string profileName);

        /// <summary>
        /// Retrieves the weekly chart asynchronously.
        /// </summary>
        /// <param name="profileName">The profile name.</param>
        /// <returns>Returns an awaitable <see cref="Task{Weeklychartlist}"/>.</returns>
        Task<Weeklychartlist> GetWeeklyChartAsync(string profileName);
    }
}
