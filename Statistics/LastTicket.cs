using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TCGaming.NET.Helpers;

namespace TCGaming.NET.Statistics
{
    /// <summary>
    /// Data relative to Last Tickets
    /// </summary>
    public class LastTicket : GlobalParameters
    {
        #region Constructors
        /// <summary>
        /// New instance of an LastTicket object
        /// </summary>
        protected LastTicket()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the [TC] World user identifier of the cop who issued the fine
        /// </summary>
        [JsonProperty("id_cop")]
        public int CopUserID { get; private set; }

        /// <summary>
        /// Gets the Live For Speed username of the cop who issued the fine
        /// </summary>
        [JsonProperty("username_cop")]
        public string COPUsername { get; private set; }

        /// <summary>
        /// Gets the Live For Speed nickname of the user who issued the fine
        /// </summary>
        [JsonProperty("cop")]
        public string CopNickname { get; private set; }

        /// <summary>
        /// Gets the Live For Speed nickname of the user who issued the fine (no colors/symbols)
        /// </summary>
        public string CopNicknameClean => CopNickname.Cleanse();

        /// <summary>
        /// Gets the [TC] World user identifier of the robber who received the fine
        /// </summary>
        [JsonProperty("id_robber")]
        public int RobberUserID { get; private set; }

        /// <summary>
        /// Gets the Live For Speed username of the robber who received the fine
        /// </summary>
        [JsonProperty("username_robber")]
        public string RobberUsername { get; private set; }

        /// <summary>
        /// Gets the Live For Speed nickname of the robber who received the fine
        /// </summary>
        [JsonProperty("robber")]
        public string RobberNickname { get; private set; }

        /// <summary>
        /// Gets the Live For Speed nickname of the user who received the fine (no colors/symbols)
        /// </summary>
        public string RobberNicknameClean => RobberNickname.Cleanse();

        /// <summary>
        /// Gets the UNIX date and time of when the ticket was issued
        /// </summary>
        [JsonProperty("date")]
        public int TicketDateUnix { get;  private set; }

        /// <summary>
        /// Gets the date and time of when the ticket was issued
        /// </summary>
        public DateTime TicketDate => TicketDateUnix.UnixTimeStampToDateTime();

        /// <summary>
        /// Gets the location/road name where the ticket was issued
        /// </summary>
        [JsonProperty("location")]
        public string TicketLocation { get; private set; }

        /// <summary>
        /// Gets the reason for the ticket issued
        /// </summary>
        [JsonProperty("offense")]
        public string TicketOffense { get; private set; }

        /// <summary>
        /// Gets the value of the ticket issued
        /// </summary>
        [JsonProperty("fine")]
        public int TicketFine { get; private set; }
        #endregion
    }
}
