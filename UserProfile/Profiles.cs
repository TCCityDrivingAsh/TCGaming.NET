using System.Collections.Generic;
using System.Linq;

namespace TCGaming.NET.UserProfile
{
    /// <summary>
    /// Portraits a collection of Profile objects
    /// </summary>
    public class Profiles : IReadOnlyCollection<Profile>
    {
        #region Constructors
        /// <summary>
        /// Initialize a new instance Profiles
        /// </summary>
        public Profiles()
        {
            _profiles = new List<Profile>();
        }
        #endregion

        #region Private Fields
        /// <summary>
        /// Stores the Profile objects for this set
        /// </summary>
        private List<Profile> _profiles { get; set; }
        #endregion

        #region Indexers
        /// <summary>
        /// Gets a <see cref="Profile"/> from the collection by a users Live For Speed Username
        /// </summary>
        /// <param name="username">Live For Speed username</param>
        /// <returns>A <see cref="Profile"/> object or <c>null</c> if no user was contained within the collection</returns>
        public Profile this[string username]
        {
            get
            {
                if (_profiles.Where(p => p.Username.ToLower() == username.ToLower()).Count() == 0)
                {
                    throw new UserNotFoundException(username);
                }
                else
                {
                    return _profiles.FirstOrDefault(p => p.Username.ToLower() == username.ToLower());
                }
            }
        }

        /// <summary>
        /// Gets a <see cref="Profile"/> from the collection by index
        /// </summary>
        /// <param name="index">Position within the collection</param>
        /// <returns>A <see cref="Profile"/> object or <c>null</c> if no user was contained within the collection</returns>
        public Profile this[int index] => _profiles[index];
        #endregion

        #region Methods
        /// <summary>
        /// Refresh all user profiles within the collection with new data
        /// </summary>
        public void RefreshAll()
        {
            foreach (Profile p in this)
            {
                p.GetData();
            }
        }

        /// <summary>
        /// Add a new user to the collection with a basic information request
        /// </summary>
        /// <param name="username">Live For Speed username</param>
        public void AddUser(string username)
        {
            if(_profiles.Count(x => x.Username.ToLower() == username.ToLower()) > 0)
            {
                throw new DuplicateVehicleException(username);
            }

            Profile p = new Profile(username);
            _profiles.Add(p);
            p.GetData();
        }

        /// <summary>
        /// Removes a user from the collection
        /// </summary>
        /// <param name="username">Live For Speed username</param>
        public void RemoveUser(string username)
        {
            if (this[username] == null) throw new UserNotFoundException(username);

            _profiles.Remove(this[username]);
        }

        /// <summary>
        /// Removes all users from the collection
        /// </summary>
        public void RemoveAll()
        {
            _profiles.Clear();
        }
        #endregion

        #region ICollection Implementation
        /// <summary>
        /// Gets the count of users within the collection
        /// </summary>
        public int Count => _profiles.Count;

        /// <summary>
        /// Gets the enumerator for this collection
        /// </summary>
        /// <returns>Enumerator</returns>
        public IEnumerator<Profile> GetEnumerator() => _profiles.GetEnumerator();

        /// <summary>
        /// Gets the enumerator for this collection
        /// </summary>
        /// <returns>Enumerator</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => _profiles.GetEnumerator();
        #endregion
    }
}
