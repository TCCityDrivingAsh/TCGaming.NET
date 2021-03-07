using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TCGaming.NET.Helpers;
using TCGaming.NET.Common;

namespace TCGaming.NET.AutoMarket
{
    /// <summary>
    /// Data relative to a vehicle listed on the [TC] AutoMarket
    /// </summary>
    public class Vehicle : VehicleBase
    {
        #region Properties
        /// <summary>
        /// Gets the UNIX date and time of when the vehicle was built
        /// </summary>
        [JsonProperty("dateBuilt")]
        public int BuildDateUnix { get; private set; }

        /// <summary>
        /// Gets the date and time of when the vehicle was built
        /// </summary>
        public DateTime BuildDate => BuildDateUnix.UnixTimeStampToDateTime();

        /// <summary>
        /// Gets the UNIX date and time of when the vehicle was first purchased
        /// </summary>
        [JsonProperty("datePurchase")]
        public int PurchaseDateUnix { get; private set; }

        /// <summary>
        /// Gets the date and time of when the vehicle was first purchased
        /// </summary>
        public DateTime PurchaseDate => PurchaseDateUnix.UnixTimeStampToDateTime();

        /// <summary>
        /// Gets the UNIX date and time of when the vehicle was listed on the [TC] AutoMarket
        /// </summary>
        [JsonProperty("onMarketSince")]
        public int ListedDateUnix { get; private set; }

        /// <summary>
        /// Gets the date and time of when the vehicle was listed on the [TC] AutoMarket
        /// </summary>
        public DateTime ListedDate => ListedDateUnix.UnixTimeStampToDateTime();

        /// <summary>
        /// Gets the number of days the vehicle has been listed for sale on the [TC] AutoMarket
        /// </summary>
        [JsonProperty("daysOnMarket")]
        public int DaysSinceListed { get; private set; }

        /// <summary>
        /// Gets the Live For Speed nickname of the previous owner
        /// </summary>
        [JsonProperty("pre_owner_nickname")]
        public string PreviousOwnerNickname { get; private set; }

        /// <summary>
        /// Gets the Live For Speed nickname of the previous owner (no colors/symbols)
        /// </summary>
        public string PreviousOwnerNicknameClean => PreviousOwnerNickname.Cleanse();
        #endregion
    }
}
