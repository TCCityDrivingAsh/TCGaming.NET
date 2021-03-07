using TCGaming.NET.Common;

namespace TCGaming.NET.Statistics
{
    /// <summary>
    /// Data relative to the Top Distance users
    /// </summary>
    public class TopDistanceUser : BaseUserWithValue
    {
        #region Properties
        /// <summary>
        /// Total distance
        /// </summary>
        private double _distance => base.Value;

        /// <summary>
        /// Gets the total distance for the user
        /// </summary>
        public Distance TotalDistance => new Distance(_distance);
        #endregion
    }
}
