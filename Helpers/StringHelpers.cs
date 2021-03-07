namespace TCGaming.NET.Helpers
{
    /// <summary>
    /// String helper methods
    /// </summary>
    public static class StringHelpers
    {
        #region Private Fields
        /// <summary>
        /// Array of translation characters prefixed with ^
        /// </summary>
        private static readonly char[] _languageChars = new char[] { 'L', 'G', 'C', 'J', 'E', 'T', 'B', 'H', 'S', 'K' };
        #endregion

        #region Methods
        /// <summary>
        /// Removes LFS formatting values from a string
        /// </summary>
        /// <param name="value">String value to remove formatting from</param>
        /// <returns>Clean string</returns>
        public static string Cleanse(this string value)
        {
            string cleanedValue = value;

            for (int i = 0; i < 9; i++)
            {
                cleanedValue = cleanedValue.Replace("^" + i, "");
            }


            foreach (char c in _languageChars)
            {
                cleanedValue = cleanedValue.Replace("^" + c, "");
            }

            return cleanedValue;
        }
        #endregion
    }
}
