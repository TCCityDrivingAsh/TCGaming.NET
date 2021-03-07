using System;

namespace TCGaming.NET.Helpers
{
    /// <summary>
    /// Extension methods
    /// </summary>
    public static class Extensions
    {
        #region Methods
        /// <summary>
        /// Converts a Unix date and time into System.DateTime object
        /// </summary>
        /// <param name="unixTimeStamp">Unix timestamp to be converted</param>
        /// <returns>Returns a <see cref="DateTime"/> object</returns>
        public static DateTime UnixTimeStampToDateTime(this int unixTimeStamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();

            return dtDateTime;
        }
        #endregion
    }
}
