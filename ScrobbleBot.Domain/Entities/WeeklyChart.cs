using System.Text.Json.Serialization;

namespace ScrobbleBot.Domain.Entities
{
    /// <summary>
    /// Represent the <see cref="WeeklyChart"/> class.
    /// </summary>
    public class WeeklyChart
    {
        /// <summary>
        /// Gets and sets the Weeklychartlist.
        /// </summary>
        [JsonPropertyName("weeklychartlist")]
        public Weeklychartlist Weeklychartlist { get; set; }
    }

    /// <summary>
    /// Represent the <see cref="Weeklychartlist"/> class.
    /// </summary>
    public class Weeklychartlist
    {
        /// <summary>
        /// Gets and sets the Chart.
        /// </summary>
        [JsonPropertyName("chart")]
        public Chart[] Chart { get; set; }

        /// <summary>
        /// Gets and sets the Attr.
        /// </summary>
        [JsonPropertyName("@attr")]
        public Attr Attr { get; set; }
    }

    /// <summary>
    /// Represent the <see cref="Chart"/> class.
    /// </summary>
    public class Chart
    {
        /// <summary>
        /// Gets and sets the Text.
        /// </summary>
        [JsonPropertyName("#text")]
        public string Text { get; set; }

        /// <summary>
        /// Gets and sets the From.
        /// </summary>
        [JsonPropertyName("from")]
        public string From { get; set; }

        /// <summary>
        /// Gets and sets the To.
        /// </summary>
        [JsonPropertyName("to")]
        public string To { get; set; }
    }
}
