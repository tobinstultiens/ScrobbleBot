using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ScrobbleBot.Domain.Entities
{
    /// <summary>
    /// Represents the <see cref="RecentTracksRoot"/> class.
    /// </summary>
    public class RecentTracksRoot
    {
        /// <summary>
        /// Gets and sets the RecentTracks
        /// </summary>
        public RecentTracks RecentTracks { get; set; }
    }

    /// <summary>
    /// Represents the <see cref="RecentTracks"/> class.
    /// </summary>
    public class RecentTracks
    {
        /// <summary>
        /// Gets and sets the Attr.
        /// </summary>
        [JsonPropertyName("attr")]
        public Attr Attr { get; set; }
        /// <summary>
        /// Gets and sets the Track.
        /// </summary>
        public List<Track> Track { get; set; }
    }

    /// <summary>
    /// Represents the <see cref="Attr"/> class.
    /// </summary>
    public class Attr
    {
        /// <summary>
        /// Gets and sets the Page.
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// Gets and sets the PerPage.
        /// </summary>
        public string PerPage { get; set; }

        /// <summary>
        /// Gets and sets the User.
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Gets and sets the Total.
        /// </summary>
        public string Total { get; set; }

        /// <summary>
        /// Gets and sets the TotalPages.
        /// </summary>
        public string TotalPages { get; set; }
    }

    /// <summary>
    /// Represents the <see cref="Track"/> class.
    /// </summary>
    public class Track
    {
        /// <summary>
        /// Gets and sets the Artist.
        /// </summary>
        [JsonPropertyName("artist")]
        public ArtistTrack Artist { get; set; }

        /// <summary>
        /// Gets and sets the Album.
        /// </summary>
        public Album Album { get; set; }

        /// <summary>
        /// Gets and sets the Image.
        /// </summary>
        public List<Image> Image { get; set; }

        /// <summary>
        /// Gets and sets the Streamable.
        /// </summary>
        public string Streamable { get; set; }

        /// <summary>
        /// Gets and sets the Date.
        /// </summary>
        public Date Date { get; set; }

        /// <summary>
        /// Gets and sets the Url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets and sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets and sets the Mbid.
        /// </summary>
        public string Mbid { get; set; }
    }

    /// <summary>
    /// Represents the <see cref="ArtistTrack"/> class.
    /// </summary>
    public class ArtistTrack
    {
        /// <summary>
        /// Gets and sets the Mbid.
        /// </summary>
        public string Mbid { get; set; }

        /// <summary>
        /// Gets and sets the Text.
        /// </summary>
        [JsonPropertyName("#text")]
        public string Text { get; set; }
    }

    /// <summary>
    /// Represents the <see cref="Album"/> class.
    /// </summary>
    public class Album
    {
        /// <summary>
        /// Gets and sets the Mbid.
        /// </summary>
        public string Mbid { get; set; }

        /// <summary>
        /// Gets and sets the Text.
        /// </summary>
        [JsonPropertyName("#text")]
        public string Text { get; set; }
    }

    /// <summary>
    /// Represents the <see cref="Date"/> class.
    /// </summary>
    public class Date
    {
        /// <summary>
        /// Gets and sets the Uts.
        /// </summary>
        public string Uts { get; set; }

        /// <summary>
        /// Gets and sets the Text.
        /// </summary>
        [JsonPropertyName("#text")]
        public string Text { get; set; }
    }
}
