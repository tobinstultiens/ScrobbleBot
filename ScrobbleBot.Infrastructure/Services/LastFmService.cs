using Microsoft.Extensions.Options;
using ScrobbleBot.Application;
using ScrobbleBot.Application.Interfaces;
using ScrobbleBot.Domain.Entities;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ScrobbleBot.Infrastructure.Services
{
    /// <summary>
    /// Represents the <see cref="LastFmService"/> class.
    /// </summary>
    public class LastFmService : ILastFmService
    {
        private readonly HttpClient _httpClient;
        private readonly ScrobbleBotConfiguration _scrobbleBotConfiguration;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="LastFmService"/> class.
        /// </summary>
        /// <param name="httpClient">The http client.</param>
        /// <param name="options">The scrobblebot configurations options.</param>
        public LastFmService(HttpClient httpClient, IOptions<ScrobbleBotConfiguration> options)
        {
            _httpClient = httpClient;
            _scrobbleBotConfiguration = options.Value;
            _jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
        }

        /// <inheritdoc cref="ILastFmService.GetProfileInfoAsync(string)"/>
        public async Task<UserProfile> GetProfileInfoAsync(string profileName)
        {
            string json = await _httpClient.GetStringAsync(CreatePath("user.getinfo", "user", profileName));
            UserProfileRoot userProfile = JsonSerializer.Deserialize<UserProfileRoot>(json, _jsonSerializerOptions);
            return userProfile.User;
        }

        /// <inheritdoc cref="ILastFmService.GetArtistInfoAsync(string)" />
        public async Task<ArtistProfile> GetArtistInfoAsync(string artistName)
        {
            string json = await _httpClient.GetStringAsync(CreatePath("artist.getinfo", "artist", artistName));
            ArtistProfileRoot artistProfile = JsonSerializer.Deserialize<ArtistProfileRoot>(json, _jsonSerializerOptions);
            return artistProfile.Artist;
        }

        /// <inheritdoc cref="ILastFmService.GetRecentTracksAsync(string)"/>
        public async Task<RecentTracks> GetRecentTracksAsync(string profileName)
        {
            string json = await _httpClient.GetStringAsync(CreatePath("user.getrecenttracks", "user", profileName));
            RecentTracksRoot recentTracks = JsonSerializer.Deserialize<RecentTracksRoot>(json, _jsonSerializerOptions);
            return recentTracks.RecentTracks;
        }

        private string CreatePath(string method, params string[] parameters)
        {
            if (parameters.Length % 2 != 0)
                throw new ArgumentOutOfRangeException(nameof(parameters));

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"?method={method}");
            for (int i = 0; i < parameters.Length; i += 2)
            {
                stringBuilder.Append($"&{parameters[i]}={parameters[i + 1]}");
            }

            stringBuilder.Append($"&api_key={_scrobbleBotConfiguration.LastFmApiKey}");
            stringBuilder.Append($"&format=json");
            return stringBuilder.ToString();
        }
    }
}
