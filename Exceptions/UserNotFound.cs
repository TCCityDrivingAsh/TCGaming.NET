using System;

namespace TCGaming.NET
{
    /// <summary>
    /// UserNotFound Exception
    /// </summary>
    public class UserNotFoundException : Exception
    {
        /// <summary>
        /// New UserNotFoundException
        /// </summary>
        public UserNotFoundException()
        {

        }

        /// <summary>
        /// New UserNotFound Exception
        /// </summary>
        /// <param name="username">Live For Speed username</param>
        public UserNotFoundException(string username) : base($"Could not find this user: '{username}'")
        {

        }
    }
}
