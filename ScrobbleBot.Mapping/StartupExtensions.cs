using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScrobbleBot.Application;
using ScrobbleBot.Application.Interfaces;
using ScrobbleBot.Infrastructure;
using ScrobbleBot.Infrastructure.Services;
using System;

namespace ScrobbleBot.Mapping
{
    /// <summary>
    /// Represents the <see cref="StartupExtensions"/> class.
    /// </summary>
    public static class StartupExtensions
    {
        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
        /// <summary>
        /// Gets a value whether the application is running in Debug mode.
        /// </summary>
        public static bool IsDebug
        {
            get
            {
                bool isDebug = false;
#if DEBUG
                isDebug = true;
#endif
                return isDebug;
            }
        }
        
        /// <summary>
        /// Converts an <see cref="IServiceProvider"/> to an <see cref="IGenericServiceProvider"/>.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>Returns a <see cref="IGenericServiceProvider"/> implementation.</returns>
        public static IGenericServiceProvider ToGenericServiceProvider(this IServiceProvider serviceProvider)
        {
            return new GenericServiceProvider(serviceProvider);
        }

        /// <summary>
        /// Adds application services.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddOptions();
            serviceCollection.Configure<ScrobbleBotConfiguration>(configuration.Bind);
            serviceCollection.AddSingleton<ILastFmService, LastFmService>();
            serviceCollection.AddHttpClient<ILastFmService, LastFmService>(client =>
            {
                client.BaseAddress = new Uri("https://ws.audioscrobbler.com/2.0/");
            });
            serviceCollection.AddSingleton<IDiscordStartupService, DiscordStartupService>();
            serviceCollection.AddSingleton(new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose,
                MessageCacheSize = 1000
            }));
            serviceCollection.AddSingleton(new CommandService(new CommandServiceConfig
            {
                LogLevel = LogSeverity.Verbose,
                DefaultRunMode = RunMode.Async
            }));
            serviceCollection.AddSingleton<ICommandHandler, CommandHandler>();
            return serviceCollection;
        }
    }
}