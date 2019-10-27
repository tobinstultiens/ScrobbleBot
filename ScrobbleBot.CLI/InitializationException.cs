using System;

namespace ScrobbleBot.CLI
{
    /// <summary>
    /// Represents the <see cref="InitializationException"/> class.
    /// Thrown when an initialization error has occurred.
    /// </summary>
    internal class InitializationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InitializationException"/> class.
        /// </summary>
        /// <param name="message"></param>
        internal InitializationException(string message) : base(message)
        {
            
        }
    }
}