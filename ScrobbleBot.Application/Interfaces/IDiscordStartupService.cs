using System.Threading.Tasks;

namespace ScrobbleBot.Application.Interfaces
{
    /// <summary>
    /// Represents the <see cref="IDiscordStartupService"/> interface.
    /// </summary>
    public interface IDiscordStartupService
    {
        /// <summary>
        /// Start the discord startup service asynchronously.
        /// </summary>
        /// <returns>Returns an awaitable <see cref="Task"/>.</returns>
        Task StartAsync();
    }
}