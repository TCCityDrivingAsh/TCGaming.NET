using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TCGaming.NET.Helpers;

namespace TCGaming.NET.UserProfile
{
    /// <summary>
    /// Data relative to an individual User Profile
    /// </summary>
    public class Profile
    {
        #region Constructors
        /// <summary>
        /// Creates an instance of Profile associated with a given username
        /// </summary>
        /// <param name="username"></param>
        public Profile(string username)
        {
            this.Username = username.ToLower();
        }
        #endregion

        #region Private Fields
        /// <summary>
        /// Gets the [TC] World user identifier of the user
        /// </summary>
        private static string _endPoint = @"/citydriving/profile";

        /// <summary>
        /// Gets whether the results should return player statistics
        /// </summary>
        private bool _stats = false;

        /// <summary>
        /// Gets whether the results should return player cars
        /// </summary>
        private bool _cars = false;

        /// <summary>
        /// Gets whether the results should return player licenses
        /// </summary>
        private bool _licenses = false;

        /// <summary>
        /// Gets whether the results should return player upgrades
        /// </summary>
        private bool _upgrades = false;

        /// <summary>
        /// Gets whether the results should return player properties
        /// </summary>
        private bool _properties = false;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the [TC] World User Identifier
        /// </summary>
        [JsonProperty("id")]
        public int UserID { get; private set; }

        /// <summary>
        /// Gets the LFS Username
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; private set; }

        /// <summary>
        /// Gets the online status of the user
        /// </summary>
        [JsonProperty("isOnline")]
        public bool Online { get; private set; }

        /// <summary>
        /// Gets the LFS Nickname of the user
        /// </summary>
        [JsonProperty("nickname")]
        public string Nickname { get; private set; }

        public string NicknameClean => Nickname.Cleanse();

        /// <summary>
        /// Gets the users Insim Admin status
        /// </summary>
        [JsonProperty("insimAdmin")]
        public bool InsimAdmin { get; private set; }

        /// <summary>
        /// Gets the users Insim Admin level
        /// </summary>
        [JsonProperty("adminLevel")]
        public int AdminLevel { get; private set; }

        /// <summary>
        /// Gets the status of the users cop training needs
        /// </summary>
        [JsonProperty("needsCopTraining")]
        public bool RequiresCopTraining { get; private set; }

        /// <summary>
        /// Gets the users money
        /// </summary>
        [JsonProperty("money")]
        public int Money { get; private set; }

        /// <summary>
        /// Gets the Unix date and time of the users first visit to a [TC] CityDriving server
        /// </summary>
        [JsonProperty("dateJoined")]
        public int JoinDateUnix { get; private set; }

        /// <summary>
        /// Gets the date and time of the users first visit to a [TC] CityDriving server
        /// </summary>
        public DateTime JoinDate => JoinDateUnix.UnixTimeStampToDateTime();

        /// <summary>
        /// Gets the Unix date and time of the users most recent visit to a [TC] CityDriving server
        /// </summary>
        [JsonProperty("dateLastSeen")]
        public int LastVisitDateUnix { get; private set; }

        /// <summary>
        /// Gets the date and time of the users most recent visit to a [TC] CityDriving server
        /// </summary>
        public DateTime LastVisitDate => LastVisitDateUnix.UnixTimeStampToDateTime();

        /// <summary>
        /// Gets the two character Country Code associated with the users connection
        /// </summary>
        [JsonProperty("countryCode")]
        public string CountryCode { get; private set; }

        /// <summary>
        /// Gets the URL to a flag representative of the users connecting country
        /// </summary>
        [JsonProperty("flag")]
        public string Flag { get; private set; }

        /// <summary>
        /// Gets the in-depth statistics of the user
        /// </summary>
        [JsonProperty("stats")]
        public Stats Stats { get; private set; }

        /// <summary>
        /// Gets a list of licenses associated to the users account
        /// </summary>
        [JsonProperty("licenses")]
        public List<License> Licenses { get; private set; }

        /// <summary>
        /// Getes a list of properties associated to the users account
        /// </summary>
        [JsonProperty("properties")]
        public List<Property> Properties { get; private set; }

        /// <summary>
        /// Gets a list of cars owned by the user
        /// </summary>
        [JsonProperty("cars")]
        public List<Vehicle> Cars { get; private set; }
        #endregion


        #region Chaining Methods
        /// <summary>
        /// Includes user statistics within the GetData request
        /// </summary>
        /// <returns>In-depth statistics</returns>
        public Profile GetStats()
        {
            this._stats = true;
            return this;
        }

        /// <summary>
        /// Includes user cars within the GetData request
        /// </summary>
        /// <returns>List of <see cref="Vehicle"/> objects</returns>
        public Profile GetCars()
        {
            this._cars = true;
            return this;
        }

        /// <summary>
        /// Includes user license details within the GetData request
        /// </summary>
        /// <returns>List of <see cref="License"/> objects</returns>
        public Profile GetLicenses()
        {
            this._licenses = true;
            return this;
        }

        /// <summary>
        /// Includes user upgrades within the GetData request
        /// </summary>
        /// <returns>List of <see cref="Upgrade"/> objects</returns>
        public Profile GetUpgrades()
        {
            this._upgrades = true;
            return this;
        }

        /// <summary>
        /// Includes user properties within the GetData request
        /// </summary>
        /// <returns>List of <see cref="Property"/> objects</returns>
        public Profile GetProperties()
        {
            this._properties = true;
            return this;
        }
        #endregion

        public Profile GetAll()
        {
            this._upgrades = true;
            this._properties = true;
            this._licenses = true;
            this._cars = true;
            this._stats = true;
            return this;
        }

        #region Methods
        /// <summary>
        /// Requests new data for this user instance
        /// </summary>
        public void GetData()
        {
            using (WebClient web = new WebClient())
            {
                web.BaseAddress = Configuration.BaseURL;

                // Build the URL string
                string url = $"/get?key={Configuration.APIKey}&username={this.Username}";
                if (_stats) url += "&stats=1";
                if (_cars) url += "&cars=1";
                if (_licenses) url += "&licenses=1";
                if (_upgrades) url += "&upgrades=1";
                if (_properties) url += "&properties=1";

                string response = null;

                try
                {
                    response = web.DownloadString(_endPoint + url);
                }
                catch (WebException ex)
                {
                    if(ex.Status == WebExceptionStatus.ProtocolError)
                    {
                        throw new UserNotFoundException(this.Username);
                    }
                }
                catch
                {
                    throw new APICallException(url);
                }

                if (response != null)
                {
                    Profile updatedProfile = JsonConvert.DeserializeObject<Profile>(response);

                    PropertyInfo[] oldProperties = this.GetType().GetProperties();
                    PropertyInfo[] newPropertiess = updatedProfile.GetType().GetProperties();

                    // Loop all existing properties, find the new related property and update the existing value
                    foreach (PropertyInfo oldProperty in oldProperties.Where(x => x.CanWrite))
                    {
                        PropertyInfo newProperty = newPropertiess.Where(x => x.Name == oldProperty.Name && x.CanWrite).FirstOrDefault();

                        oldProperty.SetValue(this, newProperty.GetValue(updatedProfile));
                    }
                }
            }
        }
        #endregion
    }
}
