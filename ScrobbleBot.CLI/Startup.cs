using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScrobbleBot.Application.Interfaces;
using ScrobbleBot.Mapping;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ScrobbleBot.CLI
{
    /// <summary>
    /// Represents the <see cref="Startup"/> class.
    /// </summary>
    public class Startup
    {
        private IGenericServiceProvider _genericServiceProvider;
        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly CancellationTokenSource _cancellationTokenSourceTimed;

        /// <summary>
        /// Prepares a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="cancellationTokenSource">The cancellation token source.</param>
        /// <param name="timeOutInSeconds">The time out in seconds.</param>
        public Startup(CancellationTokenSource cancellationTokenSource, uint timeOutInSeconds)
        {
            _cancellationTokenSource = cancellationTokenSource;
            _cancellationTokenSourceTimed = new CancellationTokenSource(TimeSpan.FromSeconds(timeOutInSeconds));
        }

        /// <summary>
        /// Initializes the <see cref="Startup"/> instance.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when the configuration is null.</exception>
        /// <returns>Returns an awaitable <see cref="Task"/>.</returns>
        public Task InitializeAsync(IConfiguration configuration, CancellationToken cancellationToken)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            _genericServiceProvider = new ServiceCollection()
                .AddApplicationServices(configuration)
                .BuildServiceProvider()
                .ToGenericServiceProvider();

            List<Task> tasks = new List<Task>
            {
                _genericServiceProvider.GetService<IDiscordStartupService>().StartAsync()
                // TODO: Add tasks for initialization.
            };
            
            return Task.WhenAll(tasks).ContinueWith(task =>
            {
                if (task.IsCanceled)
                    _cancellationTokenSource.Cancel();
            }, cancellationToken);
        }

        /// <summary>
        /// Gets the generic service provider.
        /// </summary>
        /// <exception cref="InitializationException">If <see cref="_genericServiceProvider"/> is <c>null</c>.</exception>
        /// <returns>Returns the generic service provider.</returns>
        public IGenericServiceProvider GetGenericServiceProvider()
        {
            return _genericServiceProvider ?? throw new InitializationException("GenericServiceProvider is unset. Call InitializeAsync() first.");
        }
    }
}