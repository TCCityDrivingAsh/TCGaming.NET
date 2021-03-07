using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TCGaming.NET.Common;

namespace TCGaming.NET.UserProfile
{
    /// <summary>
    /// Data relative to an individual Car
    /// </summary>
    public class Vehicle
    {
        #region Properties
        /// <summary>
        /// Gets the VIN (Vehicle Identification Number)
        /// </summary>
        [JsonProperty("vin")]
        public string VIN { get; private set; }

        /// <summary>
        /// Gets the <see cref="Cars.Models"/> type
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; private set; }

        /// <summary>
        /// Gets the total distance (in meters) travelled in this vehicle
        /// </summary>
        [JsonProperty("odometerKm")]
        private double _totalDistance { get; set; }

        /// <summary>
        /// Gets the total distance travelled in this vehicle
        /// </summary>
        public Distance TotalDistance => new Distance(_totalDistance);

        /// <summary>
        /// Gets the vehicles condition percentage
        /// </summary>
        [JsonProperty("condition")]
        public double Condition { get; private set; }

        /// <summary>
        /// Gets the vehicles wear percentage
        /// </summary>
        [JsonProperty("wear")]
        public double Wear { get; private set; }

        /// <summary>
        /// Gets the vehicles damage percentage
        /// </summary>
        [JsonProperty("damage")]
        public double Damage { get; private set; }

        /// <summary>
        /// Gets a collection of <see cref="Upgrade"/> objects relative to the vehicle
        /// </summary>
        [JsonProperty("upgrades")]
        public List<Upgrade> Upgrades { get; private set; }
        #endregion
    }
}
