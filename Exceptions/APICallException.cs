using System;

namespace TCGaming.NET
{
    /// <summary>
    /// APICall Exception
    /// </summary>
    public class APICallException : Exception
    {
        /// <summary>
        /// New APICall Exception
        /// </summary>
        public APICallException()
        {

        }

        /// <summary>
        /// New APICall Exception
        /// </summary>
        /// <param name="url">URL of the call</param>
        public APICallException(string url) : base($"Could not retreive data from '{url}'")
        {

        }
    }
}
