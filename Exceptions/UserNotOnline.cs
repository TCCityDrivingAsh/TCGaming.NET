using System;

namespace TCGaming.NET
{
    public class UserNotOnlineException : Exception
    {
        /// <summary>
        /// New UserNotOnline Exception
        /// </summary>
        public UserNotOnlineException()
        {

        }

        /// <summary>
        /// New UserNotOnline Exception
        /// </summary>
        /// <param name="username">Live For Speed username</param>
        public UserNotOnlineException(string username) : base($"Could not find this user online: '{username}'")
        {

        }
    }
}
