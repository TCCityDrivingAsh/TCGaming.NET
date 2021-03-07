using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace TCGaming.NET.Statistics
{
    /// <summary>
    /// Portraits a collecction of LastTicket objects
    /// </summary>
    public class LastTickets : GlobalParameters, IReadOnlyCollection<LastTicket>
    {
        #region Private Fields
        /// <summary>
        /// Gets the endpoint for the API call
        /// </summary>
        private static string _endPoint = @"/citydriving/stats/last_tickets";

        /// <summary>
        /// Stores the LastTicket objects for this set
        /// </summary>
        private List<LastTicket> _tickets { get; set; }
        #endregion

        #region Indexers
        /// <summary>
        /// Gets a <see cref="LastTicket"/> from the collection by index
        /// </summary>
        /// <param name="index">Position within the collection</param>
        /// <returns>A <see cref="LastTicket"/> object or <c>null</c> if no user was contained within the collection</returns>
        public LastTicket this[int index] => _tickets[index];
        #endregion

        #region Constructors
        /// <summary>
        /// New instance of LastTickets
        /// </summary>
        public LastTickets()
        {
            _tickets = new List<LastTicket>();
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

                string response = string.Empty;

                try
                {
                    response = web.DownloadString(_endPoint + $"/?key={Configuration.APIKey}&rows={RowsToReturn}&skip={RowsToSkip}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

                LastTicket[] tickets = JsonConvert.DeserializeObject<LastTicket[]>(response);

                _tickets.Clear();
                _tickets = tickets.ToList();
            }
        }
        #endregion

        #region "ICollection Implementation"
        /// <summary>
        /// Gets the count of LastTicket items in the collection
        /// </summary>
        public int Count => _tickets.Count;

        /// <summary>
        /// Gets the enumerator for this collection
        /// </summary>
        /// <returns>Enumerator</returns>
        public IEnumerator<LastTicket> GetEnumerator() => _tickets.GetEnumerator();

        /// <summary>
        /// Gets the enumerator for this collection
        /// </summary>
        /// <returns>Enumerator</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() =>_tickets.GetEnumerator();
        #endregion
    }
}
