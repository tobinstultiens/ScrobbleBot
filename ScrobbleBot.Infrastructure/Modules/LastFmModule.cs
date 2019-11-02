using Discord.Commands;
using ScrobbleBot.Application.Interfaces;
using ScrobbleBot.Domain.Entities;
using System.Threading.Tasks;

namespace ScrobbleBot.Infrastructure.Modules
{
    [Name("LastFm")]
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
            await ReplyAsync($"[{userProfile.Name}] {userProfile.Url}");
        }
    }
}
