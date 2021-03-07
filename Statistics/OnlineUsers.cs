using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using TCGaming.NET.Helpers;

namespace TCGaming.NET.Statistics
{
    /// <summary>
    /// Portraits a collection of OnlineUser objects
    /// </summary>
    public class OnlineUsers : GlobalParameters, IReadOnlyCollection<OnlineUser>
    {
        #region Constructors
        /// <summary>
        /// New instance of OnlineUsers. Defaults to All Servers
        /// </summary>
        public OnlineUsers()
        {
            _users = new List<OnlineUser>();
        }

        /// <summary>
        /// New instance of OnlineUsers. Specified by Server.
        /// </summary>
        /// <param name="server"></param>
        public OnlineUsers(Servers.Server server)
        {
            _users = new List<OnlineUser>();
            _server = server;
        }
        #endregion

        #region Private Fields
        /// <summary>
        /// Gets the endpoint for the API call
        /// </summary>
        private static string _endPoint = @"/citydriving/stats/online";

        /// <summary>
        /// Gets the server to query
        /// </summary>
        private Servers.Server _server = Servers.Server.All;

        /// <summary>
        /// Stores the OnlineUser objects for this set
        /// </summary>
        private List<OnlineUser> _users { get; set; }
        #endregion

        #region Indexers
        /// <summary>
        /// Gets a <see cref="OnlineUser"/> from the collection by a users Live For Speed Username
        /// </summary>
        /// <param name="username">Live For Speed username</param>
        /// <returns>A <see cref="OnlineUser"/> object or <c>null</c> if no user was contained within the collection</returns>
        public OnlineUser this[string username]
        {
            get
            {
                if (_users.Where(t => t.Username.ToLower() == username.ToLower()).Count() == 0)
                {
                    throw new UserNotOnlineException(username);
                }
                else
                {
                    return _users.First(t => t.Username.ToLower() == username.ToLower());
                }
            }
        }

        /// <summary>
        /// Gets a <see cref="OnlineUser"/> from the collection by index
        /// </summary>
        /// <param name="index">Position within the collection</param>
        /// <returns>A <see cref="OnlineUser"/> object or <c>null</c> if no user was contained within the collection</returns>
        public OnlineUser this[int index] => _users[index];
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
                    response = web.DownloadString(_endPoint + $"/?key={Configuration.APIKey}&server={_server.ToString().ToLower()}&rows={RowsToReturn}&skip={RowsToSkip}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

                OnlineUser[] users = JsonConvert.DeserializeObject<OnlineUser[]>(response);

                _users.Clear();
                _users = users.ToList();
            }
        }
        #endregion

        #region "ICollection Implementation"
        /// <summary>
        /// Gets the count of OnlineUser items in the collection
        /// </summary>
        public int Count => _users.Count;

        /// <summary>
        /// Gets the enumerator for this collection
        /// </summary>
        /// <returns>Enumerator</returns>
        public IEnumerator<OnlineUser> GetEnumerator() => _users.GetEnumerator();

        /// <summary>
        /// Gets the enumerator for this collection
        /// </summary>
        /// <returns>Enumerator</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => _users.GetEnumerator();
        #endregion
    }
}
