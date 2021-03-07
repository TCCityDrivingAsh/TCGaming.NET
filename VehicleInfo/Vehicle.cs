using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TCGaming.NET.Helpers;
using TCGaming.NET.Common;

namespace TCGaming.NET.VehicleInfo
{
    /// <summary>
    /// Data relative to a vehicle
    /// </summary>
    public class Vehicle : VehicleBase
    {

        #region Constructors
        /// <summary>
        /// New instance of Vehicle
        /// </summary>
        /// <param name="vin">The VIN (Vehicle Identification Number) of the vehicle</param>
        public Vehicle(string vin)
        {
            base.VIN = vin;
        }
        #endregion

        #region Private Fields
        /// <summary>
        /// Gets the endpoint for the API call
        /// </summary>
        private static string _endPoint = @"/citydriving/carinfo";
        #endregion

        #region Properties
        /// <summary>
        /// Gets the vehicle identifier
        /// </summary>
        [JsonProperty("id")]
        public int ID { get; private set; }

        /// <summary>
        /// Gets the Live For Speed username of the vehicle owner
        /// </summary>
        [JsonProperty("owner")]
        public string OwnerUsername { get; private set; }

        /// <summary>
        /// Gets the Live For Speed nickame of the vehicle owner
        /// </summary>
        [JsonProperty("nickname")]
        public string OwnerNickname { get; private set; }

        /// <summary>
        /// Gets the Live For Speed nickname of the owner (no colors/symbols)
        /// </summary>
        public string OwnerNicknameClean => OwnerNickname.Cleanse();

        /// <summary>
        /// Gets the [TC] World user identifier of the owner
        /// </summary>
        [JsonProperty("idOwner")]
        public int OwnerUserID { get; private set; }

        /// <summary>
        /// Gets the UNIX date and time of when the vehicle was built
        /// </summary>
        [JsonProperty("dateBuilt")]
        public int BuildDateUnix { get; private set; }

        /// <summary>
        /// Gets the date and tiem of when the vehicle was built
        /// </summary>
        public DateTime BuildDate =>  BuildDateUnix.UnixTimeStampToDateTime();

        /// <summary>
        /// Gets the UNIX date and time of when the vehicle was first purchased
        /// </summary>
        [JsonProperty("datePurchase")]
        public int OriginalPurchaseDateUnix { get; private set; }

        /// <summary>
        /// Gets the date and time of when the vehicle was first purchased
        /// </summary>
        public DateTime OriginalPurchaseDate => OriginalPurchaseDateUnix.UnixTimeStampToDateTime();

        /// <summary>
        /// Gets whether this vehicle is listed for sale on the [TC] AutoMarket
        /// </summary>
        [JsonProperty("isOnMarket")]
        public bool ListedForSale { get; private set; }

        /// <summary>
        /// Gets the number of previous owners
        /// </summary>
        [JsonProperty("numPreowners")]
        public int PreviousOwnerCount { get; private set; }

        /// <summary>
        /// Gets whether this vehicle is marked as written off
        /// </summary>
        [JsonProperty("isWrecked")]
        public bool TotalLoss { get; private set; }

        /// <summary>
        /// Gets the current market price of this vehicle if listed on [TC] AutoMarket
        /// </summary>
        [JsonProperty("marketPrice")]
        public int MarketPrice { get; private set; }

        /// <summary>
        /// Gets a list of previous owners
        /// </summary>
        [JsonProperty("preOwners")]
        public List<PreOwner> PreOwners { get; private set; }
        #endregion

        #region Methods
        /// <summary>
        /// Updates this objects properties with new data
        /// </summary>
        public void GetData()
        {
            using (WebClient web = new WebClient())
            {
                web.BaseAddress = Configuration.BaseURL;

                string response = string.Empty;

                try
                {
                    response = web.DownloadString(_endPoint + $"/?key={Configuration.APIKey}&vin={this.VIN}&preowners=1&upgrades=1");
                }
                catch(WebException ex)
                {
                    if(ex.Status == WebExceptionStatus.ProtocolError)
                    {
                        throw new VehicleNotFoundException(this.VIN);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

                Vehicle updatedVehicle = JsonConvert.DeserializeObject<Vehicle>(response);

                PropertyInfo[] oldProperties = this.GetType().GetProperties();
                PropertyInfo[] newPropertiess = updatedVehicle.GetType().GetProperties();

                // Loop all existing properties, find the new related property and update the existing value
                foreach(PropertyInfo oldProperty in oldProperties.Where(x => x.CanWrite))
                {
                    PropertyInfo newProperty = newPropertiess.Where(x => x.Name == oldProperty.Name && x.CanWrite).FirstOrDefault();

                    oldProperty.SetValue(this, newProperty.GetValue(updatedVehicle));
                }

                updatedVehicle = null;
            }
        }
    }
    #endregion
}

