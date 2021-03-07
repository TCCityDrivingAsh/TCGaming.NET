using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TCGaming.NET.Helpers;

namespace TCGaming.NET.UserProfile
{
    /// <summary>
    /// Data relative to an individual license
    /// </summary>
    public class License
    {
        #region Properties
        /// <summary>
        /// Gets the type of License
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; private set; }

        /// <summary>
        /// Gets the display name of the License
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// Gets the UNIX date/time the License was issued 
        /// </summary>
        [JsonProperty("dateIssued")]
        public int IssueDateUnix { get; private set; }

        /// <summary>
        /// Gets the date/time the License was issued
        /// </summary>
        public DateTime IssueDate => IssueDateUnix.UnixTimeStampToDateTime();

        /// <summary>
        /// Gets the [TC] World User ID of the issuing user
        /// </summary>
        [JsonProperty("issuedBy")]
        public int IssuedBy { get; private set; }

        /// <summary>
        /// Gets the UNIX expiry date and time the License will expire
        /// </summary>
        [JsonProperty("validUntil")]
        public int ExpiryDateUnix { get; private set; }

        /// <summary>
        /// Gets the expiry date and time the License will expire
        /// </summary>
        public DateTime ExpiryDate => ExpiryDateUnix.UnixTimeStampToDateTime();

        /// <summary>
        /// Gets the UNIX expiry date and time of a current suspension applied against this License
        /// </summary>
        [JsonProperty("suspendedUntil")]
        public int SuspensionExpiryDateUnix { get; private set; }

        /// <summary>
        /// Gets the expiry date and time of a current suspension applied against this License
        /// </summary>
        public DateTime SuspensionExpiryDate => SuspensionExpiryDateUnix.UnixTimeStampToDateTime();

        /// <summary>
        /// Gets the revoked status of this License
        /// </summary>
        [JsonProperty("revoked")]
        public bool Revoked { get; private set; }

        /// <summary>
        /// Gets the expiry status of this License
        /// </summary>
        [JsonProperty("expired")]
        public bool Expired { get; private set; }

        /// <summary>
        /// Gets the suspended status of this License
        /// </summary>
        [JsonProperty("suspended")]
        public bool Suspended { get; private set; }
        #endregion
    }
}
