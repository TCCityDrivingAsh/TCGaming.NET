using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TCGaming.NET.Common;

namespace TCGaming.NET.Statistics
{
    /// <summary>
    /// Data relative to all users currently online at a [TC] CityDriving server
    /// </summary>
    public class OnlineUser : BaseUser
    {
        #region Constructors
        /// <summary>
        /// New instance of an OnlineUser object
        /// </summary>
        protected OnlineUser()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the total money of the user
        /// </summary>
        [JsonProperty("money")]
        public int Money { get; private set; }

        /// <summary>
        /// Gets the total driven distance (in meters) for the user
        /// </summary>
        [JsonProperty("distance")]
        private double _distance { get; set; }

        /// <summary>
        /// Gets the total driven distance for the user
        /// </summary>
        public Distance Distance => new Distance(_distance);

        /// <summary>
        /// Gets the current trip distance (in meters) for the user
        /// </summary>
        [JsonProperty("trip")]
        private int _tripDistance { get; set; }

        /// <summary>
        /// Gets the current trip distance for the user
        /// </summary>
        public Distance TripDistance => new Distance(_tripDistance);

        /// <summary>
        /// Gets the current bonus value for the users trip
        /// </summary>
        [JsonProperty("bonus")]
        public int Bonus { get; private set; }

        /// <summary>
        /// Gets the <see cref="Cars.Models"/> type currently being driven by the user
        /// </summary>
        [JsonProperty("lastCar")]
        public string Car { get; private set; }

        /// <summary>
        /// Gets the last known position within the server for the user
        /// </summary>
        [JsonProperty("lastPosition")]
        public string Position { get; private set; }

        /// <summary>
        /// Gets the name of the [TC] CityDriving server the user is visiting
        /// </summary>
        [JsonProperty("server")]
        public string Server { get; private set; }
        #endregion
    }
}
