namespace TCGaming.NET
{
    /// <summary>
    /// Configuration values
    /// </summary>
    public class Configuration
    {
        #region Private Fields
        /// <summary>
        /// Gets the API key
        /// </summary>
        private static string _apiKey;

        /// <summary>
        /// Gets the base URL address for API calls
        /// </summary>
        private static string _baseURL = "https://api.tc-gaming.co.uk";
        #endregion

        #region Public Fields
        /// <summary>
        /// Gets the base URL address for API calls
        /// </summary>
        public static string BaseURL => _baseURL;

        /// <summary>
        /// Gets the API key
        /// </summary>
        public static string APIKey => _apiKey;
        #endregion

        #region Constructors
        /// <summary>
        /// New instance of Configuration. Returns 20 results as default
        /// </summary>
        static Configuration()
        {
            _apiKey = null;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds the API key to the configuration setup
        /// </summary>
        /// <param name="apiKey"></param>
        public static void AddAPIKey(string apiKey)
        {
            _apiKey = apiKey;
        }
        #endregion
    }
}
