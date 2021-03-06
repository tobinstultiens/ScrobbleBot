﻿using System;
using System.Collections.Immutable;
using Discord.Commands;
using ScrobbleBot.Application.Interfaces;
using ScrobbleBot.Domain.Entities;
using System.Threading.Tasks;
using Discord;

namespace ScrobbleBot.Infrastructure.Modules
{
    /// <summary>
    /// Represents the <see cref="LastFmModule"/> class. 
    /// </summary>
    [Name("LastFm")]
    public class LastFmModule : ModuleBase<SocketCommandContext>
    {
        private readonly ILastFmService _lastFmService;
        private readonly ICommandWebsocketService _commandWebsocketService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LastFmModule"/> class.
        /// </summary>
        /// <param name="lastFmService">The lastfm service.</param>
        /// <param name="commandWebsocketService">The Command websocket connection.</param>
        public LastFmModule(ILastFmService lastFmService, ICommandWebsocketService commandWebsocketService)
        {
            _lastFmService = lastFmService;
            _commandWebsocketService = commandWebsocketService;
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
            _commandWebsocketService.SendCommandAsync("user " + profileName, Context.User.Username);
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
            _commandWebsocketService.SendCommandAsync("artist " + artistName, Context.User.Username);
            await ReplyAsync($"[{artistProfile.Name}] {artistProfile.Bio.Summary}");
        }

        /// <summary>
        /// Command to retrieve recently listened to tracks.
        /// </summary>
        /// <param name="user">The user profile.</param>
        /// <param name="profileName">The profile name.</param>
        /// <returns>Returns an awaitable <see cref="Task"/>.</returns>
        [Command("fm")]
        public async Task GetRecentTracksAsync(string profileName = null)
        {
            RecentTracks recentTracks = await _lastFmService.GetRecentTracksAsync(profileName ?? Context.User.Username);
            EmbedBuilder embedBuilder = new EmbedBuilder
            {
                Author = new EmbedAuthorBuilder
                {
                    Name = "Requested by " + Context.User.Username,
                    IconUrl = Context.User.GetAvatarUrl(),
                    Url = $"https://www.last.fm/user/{profileName ?? Context.User.Username}"
                },
                Description = $"By {recentTracks.Track[0].Artist.Text} | {recentTracks.Track[0].Album.Text}"
            };
            Embed embed = embedBuilder.Build();
            _commandWebsocketService.SendCommandAsync("fm " + profileName, Context.User.Username);
            await ReplyAsync(embed: embed);
        }

        [Command("ws")]
        public async Task SendMessageToWebsocket(string message)
        {
            try
            {
                _commandWebsocketService.SendCommandAsync(message, Context.User.Username);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            await ReplyAsync(message);
        }

        /// <summary>
        /// Command to retrieve the weekly chart.
        /// </summary>
        /// <param name="profileName">The profile name.</param>
        /// <returns>Returns an awaitable <see cref="Task"/>.</returns>
        [Command("weeklychart")]
        public async Task GetWeeklyChartAsync(string profileName)
        {
            Weeklychartlist weeklychartlist = await _lastFmService.GetWeeklyChartAsync(profileName);
            _commandWebsocketService.SendCommandAsync("weeklychart " + profileName, Context.User.Username);
            await ReplyAsync($"{weeklychartlist.Chart}");
        }
    }
}
