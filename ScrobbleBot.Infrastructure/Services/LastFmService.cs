using ScrobbleBot.Application.Interfaces;
using ScrobbleBot.Domain.Entities;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using ScrobbleBot.Application;

namespace ScrobbleBot.Infrastructure.Services
{
    /// <summary>
    /// Represents the <see cref="LastFmService"/> class.
    /// </summary>
    public class LastFmService : ILastFmService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ScrobbleBotConfiguration _scrobbleBotConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="LastFmService"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The http client factory.</param>
        /// <param name="options">The scrobblebot configurations options.</param>
        public LastFmService(IHttpClientFactory httpClientFactory, IOptions<ScrobbleBotConfiguration> options)
        {
            _httpClientFactory = httpClientFactory;
            _scrobbleBotConfiguration = options.Value;
        }

        /// <inheritdoc cref="ILastFmService.GetProfileInfoAsync(string)"/>
        public async Task<UserProfile> GetProfileInfoAsync(string profileName)
        {
            using (HttpClient httpClient = CreateHttpClient())
            {
                string json = await httpClient.GetStringAsync(CreateUri("user.getinfo", "user", profileName));
                UserProfile userProfile = JsonSerializer.Deserialize<UserProfile>(json);
                return userProfile;
            }
        }

        private HttpClient CreateHttpClient()
        {
            HttpClient client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://ws.audioscrobbler.com/2.0/");
            return client;
        }
        private Uri CreateUri(string method, params string[] parameters)
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
            return new Uri(stringBuilder.ToString());
        }
    }
}
