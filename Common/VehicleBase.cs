using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TCGaming.NET.Common
{
    public abstract class VehicleBase
    {
        #region Properties
        /// <summary>
        /// Gets the VIN (Vehicle Identification Number)
        /// </summary>
        [JsonProperty("vin")]
        public string VIN { get; protected set; }

        /// <summary>
        /// Gets the vehicle reference code (i.e. UF1 or UF1.XMAS)
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; private set; }

        /// <summary>
        /// Gets the vehicle condition percentage
        /// </summary>
        [JsonProperty("condition")]
        public double Condition { get; private set; }

        /// <summary>
        /// Gets the vehicle wear percentage
        /// </summary>
        [JsonProperty("wear")]
        public double Wear { get; private set; }

        /// <summary>
        /// Gets the vehicle damage percentage
        /// </summary>
        [JsonProperty("damage")]
        public double Damage { get; private set; }

        /// <summary>
        /// Gets a collection of <see cref="Upgrade"/> objects relative to the vehicle
        /// </summary>
        [JsonProperty("upgrades")]
        public List<Upgrade> Upgrades { get; private set; }

        /// <summary>
        /// Gets the total distance (in meters) travelled in this vehicle
        /// </summary>
        [JsonProperty("odometerKm")]
        private double _totalDistance { get; set; }

        /// <summary>
        /// Gets the total distance travelled in this vehicle
        /// </summary>
        public Distance TotalDistance => new Distance(_totalDistance);
        #endregion

        #region Enums
        /// <summary>
        /// List of all standard LFS vehicle models
        /// </summary>
        public enum Models
        {
            XFG,
            XRG,
            BF1,
            FBM,
            FO8,
            FOX,
            FXO,
            FXR,
            FZ5,
            FZR,
            LX4,
            LX6,
            MRT,
            RAC,
            RB4,
            UF1,
            UFR,
            XFR,
            XRR,
            XRT
        }
        #endregion
    }
}
