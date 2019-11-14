using Discord.Commands;
using ScrobbleBot.Application.Interfaces;
using ScrobbleBot.Domain.Entities;
using System.Threading.Tasks;

namespace ScrobbleBot.Infrastructure.Modules
{
    /// <summary>
    /// Represents the <see cref="LastFmModule"/> class. 
    /// </summary>
    [Name("LastFm")]
    public class LastFmModule : ModuleBase<SocketCommandContext>
    {
        private readonly ILastFmService _lastFmService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LastFmModule"/> class.
        /// </summary>
        /// <param name="lastFmService">The lastfm service.</param>
        public LastFmModule(ILastFmService lastFmService)
        {
            _lastFmService = lastFmService;
        }

        /// <summary>
        /// Command to retrieve user profile information.
        /// </summary>
        /// <param name="profileName">The profile name.</param>
        /// <returns>Returns an awaitable <see cref="Task"/>.</returns>
        [Command("user")]
        public async Task GetUserProfileCommandAsync(string profileName)
        {
            UserProfile userProfile = await _lastFmService.GetProfileInfoAsync(profileName);
            await ReplyAsync($"[{userProfile.Name}] {userProfile.Url}");
        }

        /// <summary>
        /// Command to retrieve the artist profile information.
        /// </summary>
        /// <param name="artistName">The artist name.</param>
        /// <returns>Returns an awaitable <see cref="Task"/>.</returns>
        [Command("artist")]
        public async Task GetArtistProfileCommandAsync(string artistName)
        {
            ArtistProfile artistProfile = await _lastFmService.GetArtistInfoAsync(artistName);
            await ReplyAsync($"[{artistProfile.Name}] {artistProfile.Bio.Summary}");
        }

        /// <summary>
        /// Command to retrieve recently listened to tracks.
        /// </summary>
        /// <param name="profileName">The profile name.</param>
        /// <returns>Returns an awaitable <see cref="Task"/>.</returns>
        [Command("fm")]
        public async Task GetRecentTracksAsync(string profileName)
        {
            RecentTracks recentTracks = await _lastFmService.GetRecentTracks(profileName);
            await ReplyAsync($"[{recentTracks.Track[0].Artist.Text}] {recentTracks.Track[0].Name} {recentTracks.Track[0].Album.Text}");
        }
    }
}
