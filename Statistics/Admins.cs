using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace TCGaming.NET.Statistics
{
    /// <summary>
    /// Portraits a collection of Admin objects
    /// </summary>
    public class Admins : BaseTCMember, IReadOnlyCollection<BaseTCMember>
    {
        #region Constructors
        /// <summary>
        /// Initialize a new instance Crashers
        /// </summary>
        public Admins()
        {
            _users = new List<BaseTCMember>();
        }
        #endregion

        #region Private Fields
        /// <summary>
        /// Gets the endpoint for the API call
        /// </summary>
        private static string _endPoint = @"/citydriving/stats/admins";

        /// <summary>
        /// Stores the Crasher objects for this set
        /// </summary>
        private List<BaseTCMember> _users { get; set; }
        #endregion

        #region Indexers
        /// <summary>
        /// Gets a <see cref="BaseTCMember"/> from the collection by a users Live For Speed Username
        /// </summary>
        /// <param name="username">Live For Speed username</param>
        /// <returns>A <see cref="BaseTCMember"/> object or <c>null</c> if no user was contained within the collection</returns>
        public BaseTCMember this[string username]
        {
            get
            {
                if (_users.Where(t => t.Username.ToLower() == username.ToLower()).Count() == 0)
                {
                    throw new UserNotFoundException(username);
                }
                else
                {
                    return _users.First(t => t.Username.ToLower() == username.ToLower());
                }
            }
        }

        /// <summary>
        /// Gets a <see cref="BaseWithLastSeen"/> from the collection by a users [TC] World User ID
        /// </summary>
        /// <param name="index">Position within the collection</param>
        /// <returns>A <see cref="BaseWithLastSeen"/> object or <c>null</c> if no user was contained within the collection</returns>
        public BaseTCMember this[int index] => _users[index];
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

                BaseTCMember[] users = JsonConvert.DeserializeObject<BaseTCMember[]>(response);

                _users.Clear();
                _users = users.ToList();
            }
        }
        #endregion

        #region "ICollection Implementation"
        /// <summary>
        /// Gets the count of Crasher items in the collection
        /// </summary>
        public int Count => _users.Count;

        /// <summary>
        /// Gets the enumerator for this collection
        /// </summary>
        /// <returns>Enumerator</returns>
        public IEnumerator<BaseTCMember> GetEnumerator() => _users.GetEnumerator();
       

        /// <summary>
        /// Gets the enumerator for this collection
        /// </summary>
        /// <returns>Enumerator</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => _users.GetEnumerator();
        
        #endregion
    }
}
