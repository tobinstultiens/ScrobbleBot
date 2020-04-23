using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using ScrobbleBot.Application.Interfaces;
using ScrobbleBot.Domain.Entities;

namespace ScrobbleBot.Infrastructure.Modules
{
    /// <summary>
    /// Represents the <see cref="UserModule"/> class. 
    /// </summary>
    [Name("User")]
    public class UserModule : ModuleBase<SocketCommandContext>
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserModule"/> class.
        /// </summary>
        /// <param name="userService"></param>
        public UserModule(IUserService userService)
        {
            _userService = userService;
        }

        [Command("setProfile")]
        public async Task SetProfile(string profileName)
        {
            var result = await _userService.SetUserAsync(new RestUser { lastFmUsername = profileName, discordUsername = Context.User.Username });
            if (result)
            {
                await ReplyAsync("The profile has been set");
            }
            else
            {
                await ReplyAsync("Error the profile has not been set");
            }
        }

        [Command("getProfile")]
        public async Task GetProfile()
        {
            var result = await _userService.GetUserAsync(Context.User.Username);
            if (result != null)
            {
                await ReplyAsync("This is your last fm username: " + result.discordUsername);
            }
            else
            {
                await ReplyAsync("Error the profile has not been set");
            }
        }
    }
}
