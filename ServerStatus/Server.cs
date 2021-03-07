using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TCGaming.NET.ServerStatus
{
    /// <summary>
    /// Data relative to a [TC] CityDriving server
    /// </summary>
    public class Server
    {
        #region Properties
        /// <summary>
        /// Gets the online status of the server
        /// </summary>
        [JsonProperty("online")]
        public bool Online { get; private set; }

        /// <summary>
        /// Gets the track code currently in use on the server
        /// </summary>
        [JsonProperty("track")]
        public string TrackCode { get; private set; }

        /// <summary>
        /// Get the name of the track currently in use on the server
        /// </summary>
        [JsonProperty("trackName")]
        public string TrackName { get; private set; }

        /// <summary>
        /// Gets the number of guests currently on the server
        /// </summary>
        [JsonProperty("guests")]
        public int Guests { get; private set; }

        /// <summary>
        /// Gets the number of maximum guests catered for by the server
        /// </summary>
        [JsonProperty("maxGuests")]
        public int MaximumGuests { get; private set; }
        #endregion

    }
}
