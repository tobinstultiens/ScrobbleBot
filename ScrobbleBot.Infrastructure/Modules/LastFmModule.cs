using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ScrobbleBot.Application.Interfaces;
using ScrobbleBot.Domain.Entities;

namespace ScrobbleBot.Infrastructure.Modules
{
    [Group("info")]
    public class LastFmModule : ModuleBase<SocketCommandContext>
    {
        private readonly ILastFmService _lastFmService;

        public LastFmModule(ILastFmService lastFmService)
        {
            _lastFmService = lastFmService;
        }

        [Command("user")]
        public async Task GetUserProfileCommand(string profileName)
        {
            UserProfile userProfile = await _lastFmService.GetProfileInfoAsync(profileName);
            await ReplyAsync(userProfile.Name + " " + userProfile.Image);
        }
    }
}
