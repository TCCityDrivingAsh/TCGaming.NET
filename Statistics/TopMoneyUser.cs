using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TCGaming.NET.Statistics
{
    /// <summary>
    /// Data relative to the Top Money users
    /// </summary>
    public class TopMoneyUser : BaseUser
    {
        #region Constructors
        /// <summary>
        /// New instance of an TopMoneyUser object
        /// </summary>
        protected TopMoneyUser()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the total money for the user
        /// </summary>
        [JsonProperty("money")]
        public double Money { get; private set; }
        #endregion
    }
}
