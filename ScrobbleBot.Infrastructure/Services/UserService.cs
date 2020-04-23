using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ScrobbleBot.Application.Interfaces;
using ScrobbleBot.Domain.Entities;

namespace ScrobbleBot.Infrastructure.Services
{
    /// <summary>
    /// Represents the <see cref="UserService"/> class.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="httpClient">The http client.</param>
        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = false
            };
        }

        ///<inheritdoc cref="IUserService.GetUserAsync"/>
        public async Task<RestUser> GetUserAsync(string username)
        {
            string result = await _httpClient.GetStringAsync("/user/" + username);
            return JsonSerializer.Deserialize<RestUser>(result, _jsonSerializerOptions);
        }

        ///<inheritdoc cref="IUserService.SetUserAsync"/>
        public async Task<bool> SetUserAsync(RestUser restUser)
        {
            var result = await _httpClient.PostAsync("/user/",
                new StringContent(JsonSerializer.Serialize(restUser, _jsonSerializerOptions), Encoding.UTF8, "application/json"));
            return result.IsSuccessStatusCode;
        }

        ///<inheritdoc cref="IUserService.UpdateUserAsync"/>
        public async Task<bool> UpdateUserAsync(RestUser restUser)
        {
            var result = await _httpClient.PutAsync("/user/",
                new StringContent(JsonSerializer.Serialize(restUser, _jsonSerializerOptions), Encoding.UTF8, "application/json"));
            return result.IsSuccessStatusCode;
        }

        ///<inheritdoc cref="IUserService.DeleteUserAsync"/>
        public async Task<bool> DeleteUserAsync(string username)
        {
            var result = await _httpClient.DeleteAsync("/user/" + username);
            return result.IsSuccessStatusCode;
        }
    }
}
