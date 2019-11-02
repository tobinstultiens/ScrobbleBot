using System.Text.Json.Serialization;

namespace ScrobbleBot.Domain.Entities
{
    /// <summary>
    /// Represents the <see cref="ArtistProfile"/> class.
    /// </summary>
    public class ArtistProfile
    {
        /// <summary>
        /// Gets and sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets and sets the Mbid.
        /// </summary>
        public string Mbid { get; set; }

        /// <summary>
        /// Gets and sets the Url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets and sets the Image.
        /// </summary>
        public Image[] Image { get; set; }

        /// <summary>
        /// Gets and sets the Streamable.
        /// </summary>
        public string Streamable { get; set; }

        /// <summary>
        /// Gets and sets the OnTour.
        /// </summary>
        public string OnTour { get; set; }

        /// <summary>
        /// Gets and sets the Stats.
        /// </summary>
        public Stats Stats { get; set; }

        /// <summary>
        /// Gets and sets the Similar.
        /// </summary>
        public Similar Similar { get; set; }

        /// <summary>
        /// Gets and sets the Tags.
        /// </summary>
        public Tags Tags { get; set; }

        /// <summary>
        /// Gets and sets the Bio.
        /// </summary>
        public Bio Bio { get; set; }
    }

    /// <summary>
    /// Represents the <see cref="Stats"/> class.
    /// </summary>
    public class Stats
    {
        /// <summary>
        /// Gets and sets the Listeners.
        /// </summary>
        public string Listeners { get; set; }

        /// <summary>
        /// Gets and sets the PlayCount.
        /// </summary>
        public string PlayCount { get; set; }
    }

    /// <summary>
    /// Represents the <see cref="Similar"/> class.
    /// </summary>
    public class Similar
    {
        /// <summary>
        /// Gets and sets the Artist.
        /// </summary>
        public Artist[] Artist { get; set; }
    }

    /// <summary>
    /// Represents the <see cref="Artist"/> class.
    /// </summary>
    public class Artist
    {
        /// <summary>
        /// Gets and sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets and sets the Url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets and sets the Image.
        /// </summary>
        public Image[] Image { get; set; }
    }

    /// <summary>
    /// Represents the <see cref="Image"/> class.
    /// </summary>
    public class Image
    {
        /// <summary>
        /// Gets and sets the Text.
        /// </summary>
        [JsonPropertyName("#text")]
        public string Text { get; set; }

        /// <summary>
        /// Gets and sets the Size.
        /// </summary>
        public string Size { get; set; }
    }

    /// <summary>
    /// Represents the <see cref="Tags"/> class.
    /// </summary>
    public class Tags
    {
        /// <summary>
        /// Gets and sets the Tag.
        /// </summary>
        public Tag[] Tag { get; set; }
    }

    /// <summary>
    /// Represents the <see cref="Tag"/> class.
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// Gets and sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets and sets the Url.
        /// </summary>
        public string Url { get; set; }
    }

    /// <summary>
    /// Represents the <see cref="Bio"/> class.
    /// </summary>
    public class Bio
    {
        /// <summary>
        /// Gets and sets the Links.
        /// </summary>
        public Links Links { get; set; }

        /// <summary>
        /// Gets and sets the Published.
        /// </summary>
        public string Published { get; set; }

        /// <summary>
        /// Gets and sets the Summary.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets and sets the Content.
        /// </summary>
        public string Content { get; set; }
    }

    /// <summary>
    /// Represents the <see cref="Links"/> class.
    /// </summary>
    public class Links
    {
        /// <summary>
        /// Gets and sets the Link.
        /// </summary>
        public Link Link { get; set; }
    }

    /// <summary>
    /// Represents the <see cref="Link"/> class.
    /// </summary>
    public class Link
    {
        /// <summary>
        /// Gets and sets the Text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets and sets the Rel.
        /// </summary>
        public string Rel { get; set; }

        /// <summary>
        /// Gets and sets the Href.
        /// </summary>
        public string Href { get; set; }
    }
}