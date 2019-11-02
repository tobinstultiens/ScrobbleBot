namespace ScrobbleBot.Application
{
    /// <summary>
    /// Represents the <see cref="ScrobbleBotConfiguration"/> class.
    /// </summary>
    public class ScrobbleBotConfiguration
    {
        /// <summary>
        /// The lastfm api key.
        /// </summary>
        public string LastFmApiKey { get; set; }

        /// <summary>
        /// The discord api key.
        /// </summary>
        public string DiscordApiKey { get; set; }

        /// <summary>
        /// The prefix.
        /// </summary>
        public string Prefix { get; set; }
    }
}
