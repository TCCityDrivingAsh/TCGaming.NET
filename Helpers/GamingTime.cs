
using System;

namespace TCGaming.NET.Helpers
{
    /// <summary>
    /// Data reliave to Gaming times
    /// </summary>
    public class GamingTime
    {
        #region Constructors
        /// <summary>
        /// New instance of GamingTime
        /// </summary>
        /// <param name="gamingTime">Units of time in Seconds</param>
        public GamingTime(int gamingTime)
        {
            _gamingTime = gamingTime;
        }
        #endregion

        #region Private Fields
        /// <summary>
        /// Gaming time in seconds
        /// </summary>
        private int _gamingTime;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the Gaming Time in hours
        /// </summary>
        public int Hours => _gamingTime / 60 / 60;

        /// <summary>
        /// Gets the Gaming Time in minutes
        /// </summary>
        public int Minutes => _gamingTime / 60;

        /// <summary>
        /// Gets the gaming time in seconds
        /// </summary>
        public int Seconds => _gamingTime;

        /// <summary>
        /// Returns the gaming time within a TimeSpan object
        /// </summary>
        public TimeSpan TimeSpan => TimeSpan.FromSeconds(_gamingTime);
        #endregion
    }
}
