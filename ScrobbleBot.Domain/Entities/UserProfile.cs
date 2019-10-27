using System;

namespace ScrobbleBot.Domain.Entities
{
    /// <summary>
    /// Represent the <see cref="UserProfile"/> class.
    /// </summary>
    public class UserProfile
    {
        /// <summary>
        /// Gets and sets the Id.
        /// </summary>
        public double Id { get; set; }

        /// <summary>
        /// Gets and sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets and sets the RealName.
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// Gets and sets the Url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets and sets the Image.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets and sets the Country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets and sets the Age.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets and sets the Gender.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Gets and sets the Subscriber.
        /// </summary>
        public double Subscriber { get; set; }

        /// <summary>
        /// Gets and sets the PlayCount.
        /// </summary>
        public double PlayCount { get; set; }

        /// <summary>
        /// Gets and sets the Playlist.
        /// </summary>
        public int Playlist { get; set; }

        /// <summary>
        /// Gets and sets the Bootstrap.
        /// </summary>
        public int Bootstrap { get; set; }

        /// <summary>
        /// Gets and sets the Registered.
        /// </summary>
        public DateTime Registered { get; set; }
    }
}
