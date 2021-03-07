using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace TCGaming.NET.AutoMarket
{
    /// <summary>
    /// Portraits a collecction of AutoMarket Vehicles
    /// </summary>
    public class Vehicles : GlobalParameters, IReadOnlyCollection<Vehicle>
    {
        #region Constructors
        /// <summary>
        /// Initialize a new instance Vehicles. Holds data for all vehicle models.
        /// </summary>
        public Vehicles()
        {
            _vehicles = new List<Vehicle>();
        }

        /// <summary>
        /// Initialize a new instance of Vehicles. Holds data for the
        /// </summary>
        /// <param name="model">Searches for a specific <see cref="Cars.Models"/></param>
        public Vehicles(string model)
        {
            if (!Enum.IsDefined(typeof(Common.VehicleBase.Models), model))
            {
                throw new UnknownVehicleException(model);
            }

            _vehicles = new List<Vehicle>();
            _carModel = model;
        }
        #endregion

        #region Private Fields
        /// <summary>
        /// Gets the endpoint for the API call
        /// </summary>
        private static string _endPoint = @"/citydriving/market/getlist";

        /// <summary>
        /// 3 character LFS vehicle identifier
        /// </summary>
        private static string _carModel { get; set; }

        /// <summary>
        /// Stores the Vehicle objects for this set
        /// </summary>
        private List<Vehicle> _vehicles { get; set; }
        #endregion

        #region Indexers
        /// <summary>
        /// Gets a <see cref="Vehicle"/> from the collection by the vehicles VIN
        /// </summary>
        /// <param name="vin">Vehicles VIN (Vehicle Identification Number)</param>
        /// <returns>A <see cref="Vehicle"/> object or <c>null</c> if no user was contained within the collection</returns>
        public Vehicle this[string vin]
        {
            get
            {
                if (_vehicles.Where(v => v.VIN.ToLower() == vin.ToLower()).Count() == 0)
                {
                    throw new VehicleNotFoundException(vin);
                }
                else
                {
                    return _vehicles.First(v => v.VIN.ToLower() == vin.ToLower());
                }
            }
        }

        /// <summary>
        /// Gets a <see cref="Vehicle"/> from the collection by its position in the collection
        /// </summary>
        /// <param name="index">Index of <see cref="Vehicle"/> object in the collection</param>
        /// <returns>A <see cref="Vehicle"/> object or <c>null</c> if no user was contained within the collection</returns>
        public Vehicle this[int index]
        {
            get
            {
                return _vehicles[index];
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Updates this objects properties with new data
        /// </summary>
        public override void GetData()
        {
            using (WebClient web = new WebClient())
            {
                web.BaseAddress = Configuration.BaseURL;

                // Build the URL string
                string url = $"/?key={Configuration.APIKey}&updates=1&rows={RowsToReturn}&skip={RowsToSkip}";

                if (_carModel != null)
                {
                    url += $"&type={_carModel}";
                }

                string response = string.Empty;

                try
                {
                    response = web.DownloadString(_endPoint + url);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

                Vehicle[] vehicles = JsonConvert.DeserializeObject<Vehicle[]>(response);

                _vehicles.Clear();
                _vehicles = vehicles.ToList();
            }
        }
        #endregion

        #region "ICollection Implementation"
        /// <summary>
        /// Gets the count of Vehicle items in the collection
        /// </summary>
        public int Count => _vehicles.Count;

        /// <summary>
        /// Gets the enumerator for this collection
        /// </summary>
        /// <returns>Enumerator</returns>
        public IEnumerator<Vehicle> GetEnumerator() => _vehicles.GetEnumerator();

        /// <summary>
        /// Gets the enumerator for this collection
        /// </summary>
        /// <returns>Enumerator</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => _vehicles.GetEnumerator();
        #endregion
    }
}
