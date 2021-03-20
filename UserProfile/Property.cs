using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Runtime.Serialization;

namespace TCGaming.NET.UserProfile
{
    /// <summary>
    /// Data relative to a Property item
    /// </summary>
    public class Property
    {
        #region Properties
        /// <summary>
        /// Gets the Property identifer
        /// </summary>
        [JsonProperty("id")]
        public int ID { get; private set; }

        /// <summary>
        /// Gets the Property type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type")]
        public PropertyType Type { get; private set; }

        /// <summary>
        /// Gets the condition percentage of this Property
        /// </summary>
        [JsonProperty("condition")]
        public double Condition { get; private set; }

        /// <summary>
        /// Gets the market value of this Property
        /// </summary>
        [JsonProperty("value")]
        public int Value { get; private set; }
        #endregion

        #region Enums
        /// <summary>
        /// Types of available properties
        /// </summary>
        public enum PropertyType
        {
            [EnumMember(Value = "garage")]
            Garage,
            [EnumMember(Value = "locator")]
            Locator,
            [EnumMember(Value = "winch")]
            Winch,
            [EnumMember(Value = "ramp")]
            Ramp
        }
        #endregion
    }
}
