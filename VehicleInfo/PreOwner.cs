using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TCGaming.NET.Helpers;
using TCGaming.NET.Common;

namespace TCGaming.NET.VehicleInfo
{
    /// <summary>
    /// Data relative to an previous owner of a vehicle
    /// </summary>
    public class PreOwner
    {
        #region Constructors
        /// <summary>
        /// New instance of an PreOwner object
        /// </summary>
        protected PreOwner()
        {

        }
        #endregion

        /// <summary>
        /// Gets the Live For Speed username of the previous owner
        /// </summary>
        [JsonProperty("buyer")]
        public string Buyer { get; private set; }

        /// <summary>
        /// Gets the [TC] World user identifier of the previous owner
        /// </summary>
        [JsonProperty("buyerId")]
        public string BuyerID { get; private set; }

        /// <summary>
        /// Gets the UNIX date and time of the vehicle purchase
        /// </summary>
        [JsonProperty("datePurchase")]
        public int DatePurchasedUnix { get; private set; }

        /// <summary>
        /// Gets the date and time of the vehicle purchase
        /// </summary>
        public DateTime DatePurchased => DatePurchasedUnix.UnixTimeStampToDateTime();

        /// <summary>
        /// Gets the total Kilometers driven during the ownership
        /// </summary>
        [JsonProperty("odometerKm")]
        private double _totalKM { get; set; }

        /// <summary>
        /// Gets the total milage driven at the point of ownership
        /// </summary>
        public Distance TotalMileage => new Distance(_totalKM, Distance.DistanceType.Kilometers);
    }
}
