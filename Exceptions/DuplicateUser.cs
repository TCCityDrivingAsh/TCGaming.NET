using System;

namespace TCGaming.NET
{
    /// <summary>
    /// DuplicateUser Exception
    /// </summary>
    public class DuplicateUserException : Exception
    {
        /// <summary>
        /// New DuplicateUserException
        /// </summary>
        public DuplicateUserException()
        {

        }

        /// <summary>
        /// New DuplicateUserException
        /// </summary>
        /// <param name="username">Live For Speed username</param>
        public DuplicateUserException(string username) : base($"This user already exists: '{username}'")
        {

        }
    }
}
