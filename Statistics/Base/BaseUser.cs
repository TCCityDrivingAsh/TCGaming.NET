using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TCGaming.NET.Helpers;

namespace TCGaming.NET.Statistics
{
    /// <summary>
    /// Shared Statistics across all stats objects
    /// </summary>
    public class BaseUser : GlobalParameters
    {
        #region Constructors
        /// <summary>
        /// New instance of an BaseUser object
        /// </summary>
        protected BaseUser()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the [TC] World user identifier of the user
        /// </summary>
        [JsonProperty("id")]
        public int UserID { get; private set; }

        /// <summary>
        /// Gets the two character Country code of the user
        /// </summary>
        [JsonProperty("countrycode")]
        public string CountryCode { get; private set; }

        /// <summary>
        /// Gets the Live For Speed username of the user
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; private set; }

        /// <summary>
        /// Gets the Live For Speed nickname of the user
        /// </summary>
        [JsonProperty("nickname")]
        public string Nickname { get; private set; }

        /// <summary>
        /// Gets the Live For Speed nickname of the user (no colors/symbols)
        /// </summary>
        public string NicknameClean => Nickname.Cleanse();
        #endregion
    }
}
