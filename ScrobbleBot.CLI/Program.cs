using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ScrobbleBot.Mapping;

namespace ScrobbleBot.CLI
{
    /// <summary>
    /// Represents the <see cref="Program"/> class.
    /// </summary>
    public class Program
    {
        private static readonly CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();
        private IGenericServiceProvider _genericServiceProvider;
        private static int _canReadConsole;
        private static int _canExit;

        /// <summary>
        /// Initializes the <see cref="Program"/> class.
        /// </summary>
        /// <param name="args">The args.</param>
        public static async Task Main(string[] args)
        {
            Task task = new Program().RunAsync(CancellationTokenSource.Token);
            _ = Task.Run(() => task);

            while (!CancellationTokenSource.IsCancellationRequested)
            {
                if (Interlocked.CompareExchange(ref _canReadConsole, 0, 0) == 0)
                {
                    await Task.Delay(500);
                    continue;
                }

                if (Console.ReadKey().Key == ConsoleKey.Q)
                {
                    CancellationTokenSource.Cancel();
                    continue;
                }
                Console.WriteLine("\nPress Q to shut down the ScrobbleBot.");
            }
            if (Interlocked.CompareExchange(ref _canExit, 1, 1) == 0)
            {
                try
                {
                    await task;
                }
                catch (Exception)
                {
                    Console.WriteLine("RunAsync cancelled.");
                }
            }

            Console.WriteLine("\nScrobbleBot has shut down");
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }

        /// <summary>
        /// Runs the program asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns an awaitable <see cref="Task"/>.</returns>
        private async Task RunAsync(CancellationToken cancellationToken)
        {
            IConfiguration configuration;
            
            try
            {
                IConfigurationBuilder builder = new ConfigurationBuilder()
                    .SetBasePath(Environment.CurrentDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                configuration = builder.Build();
            }
            catch (Exception)
            {
                Console.WriteLine("Please check if you have a valid appsettings.json!");
                CancellationTokenSource.Cancel();
                return;
            }

            Startup startup = new Startup(CancellationTokenSource, 60);
            Console.WriteLine("Initializing...");
            await startup.InitializeAsync(configuration, cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();
            Console.WriteLine("Finished initializing!\n");

            _genericServiceProvider = startup.GetGenericServiceProvider();
            
            // TODO: Start whatever services we need.
        }
    }
}