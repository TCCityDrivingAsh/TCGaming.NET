using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TCGaming.NET.Helpers;
using TCGaming.NET.Common;

namespace TCGaming.NET.Statistics
{
    /// <summary>
    /// Data relative to newly welcomed players
    /// </summary>
    public class NewPlayer : BaseUser
    {
        #region Constructors
        /// <summary>
        /// New instance of an NewPlayer object
        /// </summary>
        protected NewPlayer()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the money held by the user
        /// </summary>
        [JsonProperty("money")]
        public double Money { get; private set; }

        /// <summary>
        /// Gets the UNIX date and time of when the player first joined a [TC] CityDriving server
        /// </summary>
        [JsonProperty("dateJoined")]
        public int JoinDateUnix { get; private set; }

        /// <summary>
        /// Gets the date and time of when the player first joined a [TC] CityDriving server
        /// </summary>
        public DateTime JoinDate => JoinDateUnix.UnixTimeStampToDateTime();

        /// <summary>
        /// Gets the total distance (in meters) travelled by the user
        /// </summary>
        [JsonProperty("distance")]
        private double _distance { get; set; }

        /// <summary>
        /// Gets the total distance 
        /// </summary>
        public Distance Distance => new Distance(_distance);
        #endregion
    }
}
