using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TCGaming.NET.Helpers;
using TCGaming.NET.Common;

namespace TCGaming.NET.Statistics
{
    /// <summary>
    /// Gets individual player data relative to the most recent Gumball 3000 event
    /// </summary>
    public abstract class GumballPlayer : BaseUser
    {
        #region Properties
        /// <summary>
        /// Gets the initial distance (in meters) value of the user at the start of the event
        /// </summary>
        [JsonProperty("start_distance")]
        private double _startDistance { get; set; }

        /// <summary>
        /// Gets the initial distance value of the user at the start of the event
        /// </summary>
        public Distance StartDistance => new Distance(_startDistance);

        /// <summary>
        /// Gets the UNIX date and time at the start of the event
        /// </summary>
        [JsonProperty("start_time")]
        public int StartTimeUnix { get; private set; }

        /// <summary>
        /// Gets the date and time at the start of the event
        /// </summary>
        public DateTime StartTime =>  StartTimeUnix.UnixTimeStampToDateTime();

        /// <summary>
        /// Gets the current UNIX date and time
        /// </summary>
        [JsonProperty("current_time")]
        public int CurrentTimeUnix { get; private set; }

        /// <summary>
        /// Gets the current date and time
        /// </summary>
        public DateTime CurrentTime => CurrentTimeUnix.UnixTimeStampToDateTime();

        /// <summary>
        /// Gets the current distance (in meters) driven by the user
        /// </summary>
        [JsonProperty("current_distance")]
        private double _currentDistance { get; set; }

        /// <summary>
        /// Gets the current distance driven by the user
        /// </summary>
        public Distance CurrentDistance => new Distance(_currentDistance);

        /// <summary>
        /// Gets the total distance (in meters) driven by the user for the event
        /// </summary>
        [JsonProperty("gumball_distance")]
        private int _gumballDistance { get; set; }

        /// <summary>
        /// Gets the total distance driven by the user for the event
        /// </summary>
        public Distance GumballDistance => new Distance(_gumballDistance);

        /// <summary>
        /// Gets the total time (in seconds) the event has been running
        /// </summary>
        [JsonProperty("gumball_time")]
        private int _gumballTime { get; set; }

        /// <summary>
        /// Gets the total time the event has been running
        /// </summary>
        public GamingTime GumballTime => new GamingTime(_gumballTime);

        /// <summary>
        /// Gets the average speed of the user during the event
        /// </summary>
        [JsonProperty("avg_speed")]
        public int EventAverageSpeed { get; private set; }

        /// <summary>
        /// Gets the UNIX date and time point the user was last seen in a [TC] CityDriving server
        /// </summary>
        [JsonProperty("last_seen_ago")]
        public int LastSeenUnix { get; private set; }

        /// <summary>
        /// Gets the date and time point the user was last seen in a [TC] CityDriving server
        /// </summary>
        public DateTime LastSeen => LastSeenUnix.UnixTimeStampToDateTime();

        /// <summary>
        /// Gets the name of the [TC] CityDriving server the user is playing in
        /// </summary>
        [JsonProperty("server")]
        public string Server { get; private set; }
        #endregion
    }
}
