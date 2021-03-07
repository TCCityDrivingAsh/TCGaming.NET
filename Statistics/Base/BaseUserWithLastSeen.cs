using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TCGaming.NET.Helpers;

namespace TCGaming.NET.Statistics
{
    /// <summary>
    /// Base statistics with Last Seen data
    /// </summary>
    public class BaseUserWithLastSeen : BaseUser
    {
        #region Constructors
        /// <summary>
        /// New instance of an BaseUserWithLastSeen object
        /// </summary>
        protected BaseUserWithLastSeen()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the UNIX date and time the user was last seen in a [TC] CityDriving server
        /// </summary>
        [JsonProperty("lastSeen")]
        public int LastSeenUnix { get; private set; }

        /// <summary>
        /// Gets the date and time the user was last seen in a [TC] CityDriving server
        /// </summary>
        public DateTime LastSeen => LastSeenUnix.UnixTimeStampToDateTime();
        #endregion
    }
}
