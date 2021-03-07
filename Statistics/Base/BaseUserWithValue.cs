using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TCGaming.NET.Statistics
{
    /// <summary>
    /// Base statistics with Value data
    /// </summary>
    public class BaseUserWithValue : BaseUser
    {
        #region Constructors
        /// <summary>
        /// New instance of an BaseUserWithValue object
        /// </summary>
        protected BaseUserWithValue()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the value
        /// </summary>
        [JsonProperty("value")]
        public double Value { get; private set; }
        #endregion
    }
}
