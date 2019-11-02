using System.Collections.Generic;

namespace ScrobbleBot.Domain.Entities
{
    /// <summary>
    /// Represent the <see cref="UserProfile"/> class.
    /// </summary>
    public class UserProfile
    {
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
        /// Gets and sets the list of Images.
        /// </summary>
        public List<Image> Image { get; set; }

        /// <summary>
        /// Gets and sets the Country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets and sets the Age.
        /// </summary>
        public string Age { get; set; }

        /// <summary>
        /// Gets and sets the Gender.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Gets and sets the Subscriber.
        /// </summary>
        public string Subscriber { get; set; }

        /// <summary>
        /// Gets and sets the PlayCount.
        /// </summary>
        public string PlayCount { get; set; }

        /// <summary>
        /// Gets and sets the Playlist.
        /// </summary>
        public string Playlist { get; set; }

        /// <summary>
        /// Gets and sets the Bootstrap.
        /// </summary>
        public string Bootstrap { get; set; }

        /// <summary>
        /// Gets and sets the Registered.
        /// </summary>
        public Registered Registered { get; set; }
    }

    /// <summary>
    /// Represent the <see cref="UserProfileRoot"/> class.
    /// </summary>
    public class UserProfileRoot
    {
        /// <summary>
        /// Gets and sets the user profile.
        /// </summary>
        public UserProfile User { get; set; }
    }

    /// <summary>
    /// Represents the <see cref="Registered"/> class.
    /// </summary>
    public class Registered
    {
        /// <summary>
        /// Gets and sets the unix time.
        /// </summary>
        public string UnixTime { get; set; }
    }
}
