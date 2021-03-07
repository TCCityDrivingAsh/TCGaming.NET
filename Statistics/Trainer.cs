using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace TCGaming.NET.Statistics
{
    /// <summary>
    /// Data relative to the [TC] Training users
    /// </summary>
    public class Trainer : BaseUserWithLastSeen
    {
        #region Constructors
        /// <summary>
        /// New instance of an Trainer object
        /// </summary>
        protected Trainer()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the users Trainer level ID
        /// </summary>
        [JsonProperty("trainer_level")]
        public int TrainerLevel { get; private set; }

        /// <summary>
        /// Gets the users Trainer level rank
        /// </summary>
        public string Rank => Ranks[TrainerLevel];
        #endregion

        #region Dictionaries
        /// <summary>
        /// Dictionary containing the Trainer Level ID and corresponding rank description
        /// </summary>
        public static readonly Dictionary<int, string> Ranks = new Dictionary<int, string>()
        {
            {1, "Leader" },
            {2, "Trainer" },
            {3, "Assistant" },
            {4, "Civillian Assistant" }
        };
        #endregion
    }
}
