using System;
using System.Linq;
using System.Net;
using System.Reflection;
using Newtonsoft.Json;

namespace TCGaming.NET.ServerStatus
{
    /// <summary>
    /// Data relative to a [TC] CityDriving server
    /// </summary>
    public class Status : GlobalParameters 
    {
        #region Private Fields
        /// <summary>
        /// Gets the endpoint for the API call
        /// </summary>
        private static string _endPoint = @"/citydriving/live/status";
        #endregion

        #region Properties
        /// <summary>
        /// Gets the status of [TC] CityDriving One
        /// </summary>
        [JsonProperty("one")]
        public Server One { get; private set; }

        /// <summary>
        /// Gets the status of [TC] CityDriving Twp
        /// </summary>
        [JsonProperty("two")]
        public Server Two { get; private set; }

        /// <summary>
        /// Gets the status of [TC] CityDriving Three
        /// </summary>
        [JsonProperty("three")]
        public Server Three { get; private set; }

        /// <summary>
        /// Gets the status of [TC] CityDriving Event
        /// </summary>
        [JsonProperty("events")]
        public Server Events { get; private set; }

        /// <summary>
        /// Gets the status of [TC] CityDriving Training
        /// </summary>
        [JsonProperty("training")]
        public Server Training { get; private set; }
        #endregion

        #region Methods
        /// <summary>
        /// Updates each Server object's properties with new data
        /// </summary>
        public override void GetData()
        {
            using (WebClient web = new WebClient())
            {
                web.BaseAddress = Configuration.BaseURL;

                string response = string.Empty;

                try
                {
                    response = web.DownloadString(_endPoint + $"?key={Configuration.APIKey}&server=all");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

                if (response != null)
                {
                    Status status = JsonConvert.DeserializeObject<Status>(response);

                    PropertyInfo[] oldProperties = this.GetType().GetProperties();
                    PropertyInfo[] newPropertiess = status.GetType().GetProperties();

                    // Loop all existing properties, find the new related property and update the existing value
                    foreach (PropertyInfo oldProperty in oldProperties.Where(x => x.CanWrite))
                    {
                        PropertyInfo newProperty = newPropertiess.Where(x => x.Name == oldProperty.Name && x.CanWrite).FirstOrDefault();

                        oldProperty.SetValue(this, newProperty.GetValue(status));
                    }
                }

            }
        }
        #endregion
    }

}