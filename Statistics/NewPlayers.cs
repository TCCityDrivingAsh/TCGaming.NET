using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace TCGaming.NET.Statistics
{
    /// <summary>
    /// Portraits a collecction of NewPlayer objects
    /// </summary>
    public class NewPlayers : GlobalParameters, IReadOnlyCollection<NewPlayer>
    {
        #region Constructors
        /// <summary>
        /// Initialize a new instance TCMembers
        /// </summary>
        public NewPlayers()
        {
            _users = new List<NewPlayer>();
        }
        #endregion

        #region Private Fields
        /// <summary>
        /// Gets the endpoint for the API call
        /// </summary>
        private static string _endPoint = @"/citydriving/stats/new_players";

        /// <summary>
        /// Stores the TCMember objects for this set
        /// </summary>
        private List<NewPlayer> _users { get; set; }
        #endregion

        #region Indexers
        /// <summary>
        /// Gets a <see cref="NewPlayer"/> from the collection by index
        /// </summary>
        /// <param name="index">Position within the collection</param>
        /// <returns>A <see cref="NewPlayer"/> object or <c>null</c> if no user was contained within the collection</returns>
        public NewPlayer this[int index] => _users[index];
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

                NewPlayer[] users = JsonConvert.DeserializeObject<NewPlayer[]>(response);

                _users.Clear();
                _users = users.ToList();
            }
        }
        #endregion

        #region "ICollection Implementation"
        /// <summary>
        /// Gets the count of NewPlayer items in the collection
        /// </summary>
        public int Count => _users.Count;

        /// <summary>
        /// Gets the enumerator for this collection
        /// </summary>
        /// <returns>Enumerator</returns>
        public IEnumerator<NewPlayer> GetEnumerator() => _users.GetEnumerator();

        /// <summary>
        /// Gets the enumerator for this collection
        /// </summary>
        /// <returns>Enumerator</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => _users.GetEnumerator();
        #endregion
    }
}
