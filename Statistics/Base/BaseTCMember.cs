using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TCGaming.NET.Helpers;

namespace TCGaming.NET.Statistics
{
    /// <summary>
    /// Shared Statistics across all TC Gaming Member related objects
    /// </summary>
    public class BaseTCMember : BaseUser
    {
        #region Constructors
        /// <summary>
        /// New instance of an BaseTCMember object
        /// </summary>
        protected BaseTCMember()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the users Admin level
        /// </summary>
        [JsonProperty("adminLevel")]
        public int AdminLevel { get; private set; }

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
