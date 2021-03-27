using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Runtime.Serialization;

namespace TCGaming.NET.Common
{
    public class Upgrade
    {
        #region Properties
        /// <summary>
        /// Gets the item identifer
        /// </summary>
        [JsonProperty("id")]
        public int ID { get; private set; }

        /// <summary>
        /// Gets the Upgrade type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type")]
        public UpgradeType Type { get; private set; }

        /// <summary>
        /// Gets the condition percentage of this item
        /// </summary>
        [JsonProperty("condition")]
        public double Condition { get; private set; }

        /// <summary>
        /// Gets the market value of this item
        /// </summary>
        [JsonProperty("value")]
        public int Value { get; private set; }
        #endregion

        #region Enums
        /// <summary>
        /// Types of available upgrade item
        /// </summary>
        public enum UpgradeType
        {
            [EnumMember(Value = "car_alarm")]
            Alarm,
            [EnumMember(Value = "anpr_camera")]
            ANPR,
            [EnumMember(Value = "radar_warner")]
            Radar,
            [EnumMember(Value = "ramp")]
            Ramp,
            [EnumMember(Value = "winch")]
            Winch,
            [EnumMember(Value = "garage")]
            Garage,
            [EnumMember(Value = "locator")]
            Locator
        }
        #endregion
    }
}
