using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Options;
using ScrobbleBot.Application;
using ScrobbleBot.Application.Interfaces;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace ScrobbleBot.Infrastructure.Services
{
    /// <summary>
    /// Represents the <see cref="DiscordStartupService"/> class.
    /// </summary>
    public class DiscordStartupService : IDiscordStartupService
    {
        private readonly DiscordSocketClient _discordSocketClient;
        private readonly CommandService _commandService;
        private readonly IServiceProvider _serviceProvider;
        private readonly ScrobbleBotConfiguration _scrobbleBotConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiscordStartupService"/> class.
        /// </summary>
        /// <param name="options">The scrobble bot configuration options.</param>
        /// <param name="discordSocketClient">The discord socket client.</param>
        /// <param name="commandService">The command service.</param>
        /// <param name="serviceProvider">The service provider.</param>
        public DiscordStartupService(
            IOptions<ScrobbleBotConfiguration> options,
            DiscordSocketClient discordSocketClient,
            CommandService commandService,
            IServiceProvider serviceProvider)
        {
            _discordSocketClient = discordSocketClient;
            _commandService = commandService;
            _serviceProvider = serviceProvider;
            _scrobbleBotConfiguration = options.Value;
        }

        /// <inheritdoc cref="IDiscordStartupService.StartAsync"/>
        public async Task StartAsync()
        {
            Console.WriteLine("Discord Startup service starting...");
            if (string.IsNullOrWhiteSpace(_scrobbleBotConfiguration.DiscordApiKey))
                throw new ArgumentException("Discord bot key was not set in the appsettings.json.", nameof(_scrobbleBotConfiguration.DiscordApiKey));

            await _discordSocketClient.LoginAsync(TokenType.Bot, _scrobbleBotConfiguration.DiscordApiKey);
            Console.WriteLine("Logged in.");
        
            await _discordSocketClient.StartAsync();
            Console.WriteLine("Started Discord Socket Client.");

            await _commandService.AddModulesAsync(Assembly.GetAssembly(typeof(DiscordStartupService)), _serviceProvider);
            Console.WriteLine("Added modules.");
            Console.WriteLine("Discord Startup service started!");
        }
    }
}