using System.Threading.Tasks;

namespace ScrobbleBot.Application.Interfaces
{
    /// <summary>
    /// Represents the <see cref="ICommandWebsocketService"/> interface.
    /// </summary>
    public interface ICommandWebsocketService
    {
        /// <summary>
        /// Send command asynchronously.
        /// </summary>
        /// <returns></returns>
        void SendCommandAsync(string command, string username);
    }
}