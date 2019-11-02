using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Options;
using ScrobbleBot.Application;
using ScrobbleBot.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace ScrobbleBot.Infrastructure
{
    /// <summary>
    /// Represents the <see cref="CommandHandler"/> class.
    /// </summary>
    public class CommandHandler : ICommandHandler
    {
        private readonly DiscordSocketClient _discordSocketClient;
        private readonly CommandService _commandService;
        private readonly ScrobbleBotConfiguration _scrobbleBotConfiguration;
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandHandler"/> class.
        /// </summary>
        /// <param name="discordSocketClient">The discord socket client.</param>
        /// <param name="commandService">The command service.</param>
        /// <param name="scrobbleBotConfigurationOptions">The scrobble bot configuration options.</param>
        /// <param name="serviceProvider">The service provider.</param>
        public CommandHandler(
            DiscordSocketClient discordSocketClient,
            CommandService commandService,
            IOptions<ScrobbleBotConfiguration> scrobbleBotConfigurationOptions,
            IServiceProvider serviceProvider)
        {
            _discordSocketClient = discordSocketClient;
            _commandService = commandService;
            _scrobbleBotConfiguration = scrobbleBotConfigurationOptions.Value;
            _serviceProvider = serviceProvider;
            _discordSocketClient.MessageReceived += OnMessageReceivedAsync;
        }

        private async Task OnMessageReceivedAsync(SocketMessage s)
        {
            if (!(s is SocketUserMessage msg)) return;
            if (msg.Author.Id == _discordSocketClient.CurrentUser.Id) return;

            SocketCommandContext context = new SocketCommandContext(_discordSocketClient, msg);

            int argPos = 0;
            if (msg.HasStringPrefix(_scrobbleBotConfiguration.Prefix, ref argPos) || msg.HasMentionPrefix(_discordSocketClient.CurrentUser, ref argPos))
            {
                IResult result = await _commandService.ExecuteAsync(context, argPos, _serviceProvider);

                if (!result.IsSuccess)
                    await context.Channel.SendMessageAsync(result.ToString());
            }
        }
    }
}
