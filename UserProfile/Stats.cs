using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TCGaming.NET.Statistics;
using TCGaming.NET.Common;
using System.Collections.Generic;
using TCGaming.NET.Helpers;

namespace TCGaming.NET.UserProfile
{
    /// <summary>
    /// Gets statistical data relative to a <see cref="Profile"/>
    /// </summary>
    public class Stats
    {
        #region Properties
        /// <summary>
        /// Gets the total value sent from this user account
        /// </summary>
        [JsonProperty("sent_money")]
        public int MoneySent { get; private set; }

        /// <summary>
        /// Gets the total value received by this user account
        /// </summary>
        [JsonProperty("received_money")]
        public int MoneyReceived { get; private set; }

        /// <summary>
        /// Gets the total value received by this user as refunds from Administrators
        /// </summary>
        [JsonProperty("earned_refunds")]
        public int EarnedRefunds { get; private set; }

        /// <summary>
        /// Gets the total value spent by this user renting vehicles
        /// </summary>
        [JsonProperty("paid_for_renting")]
        public int RentalCharges { get; private set; }

        /// <summary>
        /// Gets the total value this user has gained from busts whilst playing as a COP
        /// </summary>
        [JsonProperty("received_fines")]
        public int ReceivedFines { get; private set; }

        /// <summary>
        /// Gets the total value this user has paid out in fines as a result of being captured during a pursuit
        /// </summary>
        [JsonProperty("paid_fines")]
        public int PaidFines { get; private set; }

        /// <summary>
        /// Gets the total monetry this user has paid out in fines as a result of being caught by a speed trap
        /// </summary>
        [JsonProperty("paid_radar_fines")]
        public int PaidRadarFines { get; private set; }

        /// <summary>
        /// Gets the total kilometer (KM) travelled by this user
        /// </summary>
        [JsonProperty("driven_distance")]
        private double _drivenDistance { get; set; }

        /// <summary>
        /// Gets the total distance travelled by this user
        /// </summary>
        public Distance DrivenDistance => new Distance(_drivenDistance);

        /// <summary>
        /// Gets the total income value of driving (i.e. staying within the speed limits)
        /// </summary>
        [JsonProperty("driving_money_plus")]
        public int DrivingMoneyIn { get; private set; }

        /// <summary>
        /// Gets the total outgoing value as a result of driving (i.e. speeding)
        /// </summary>
        [JsonProperty("driving_money_minus")]
        public int DrivingMoneyOut { get; private set; }

        /// <summary>
        /// Gets the total value of all given donations from this user
        /// </summary>
        [JsonProperty("paid_donation")]
        public int PaidDonations { get; private set; }

        /// <summary>
        /// Gets the total value of all received donations by this user
        /// </summary>
        [JsonProperty("received_donation")]
        public int ReceivedDonations { get; private set; }

        /// <summary>
        /// Gets the total value of compensation given from this user (i.e. !sorry)
        /// </summary>
        [JsonProperty("paid_compensation")]
        public int CompensationPaid { get; private set; }

        /// <summary>
        /// Gets the total value of compensation received from this user (i.e. !sorry)
        /// </summary>
        [JsonProperty("received_compensation")]
        public int CompensationReceived { get; private set; }

        /// <summary>
        /// Gets the total number of crashes this user has been involved in
        /// </summary>
        [JsonProperty("crashes")]
        public int Crashes { get; private set; }

        /// <summary>
        /// Gets the total value of fines paid due to destruction of City property (i.e. traffic lights)
        /// </summary>
        [JsonProperty("16")]
        public int PaidDestructionFines { get; private set; }

        /// <summary>
        /// Gets the total occourences this user has been evaded pursuing cops
        /// </summary>
        [JsonProperty("chases_won_robber")]
        public int ChasesWonAsRobber { get; private set; }

        /// <summary>
        /// Gets the total occourences this user has been busted by pursuing cops
        /// </summary>
        [JsonProperty("chases_lost_robber")]
        public int ChasesLostAsRobber { get; private set; }

        /// <summary>
        /// Gets the total occurences this user has been involved in a successful pursuit
        /// </summary>
        [JsonProperty("cases_won_cop")]
        public int ChasesCapturedAsCop { get; private set; }

        /// <summary>
        /// Gets the total occourences this user has terminated a pursuit (as a result of !lost or loosing contact with suspect)
        /// </summary>
        [JsonProperty("chases_lost_cop")]
        public int ChasesLostAsCop { get; private set; }

        /// <summary>
        /// Gets the total occourences this user has attempted to steal from other users
        /// </summary>
        [JsonProperty("40")]
        public int AttemptedThefts { get; private set; }

        /// <summary>
        /// Gets the total occourences this user has successfully stolen from other users
        /// </summary>
        [JsonProperty("41")]
        public int CommitedThefts { get; private set; }

        /// <summary>
        /// Gets the total value earned by stealing from other users
        /// </summary>
        [JsonProperty("42")]
        public double EarnedFromStealing { get; private set; }

        /// <summary>
        /// Gets the total number of cops this user has outrun
        /// </summary>
        [JsonProperty("outran_cops")]
        public int OutranCops { get; private set; }

        /// <summary>
        /// Gets the users net worth/wealth value
        /// </summary>
        [JsonProperty("net_value")]
        public int Wealth { get; private set; }

        /// <summary>
        /// Gets the total time (in seconds) this user has played within a [TC] CityDriving server
        /// </summary>
        [JsonProperty("gaming_time_total")]
        private int _gamingTimeAll { get; set; }

        /// <summary>
        /// Gets the total gaming time this user has played within a [TC] CityDriving server
        /// </summary>
        public GamingTime GamingTimeAll => new GamingTime(_gamingTimeAll);

        /// <summary>
        /// Gets the total time (in seconds) this user has played as a COP within a [TC] CityDriving server
        /// </summary>
        [JsonProperty("gaming_time_cop")]
        private int _gamingTimeCop { get; set; }

        /// <summary>
        /// Gets the total gaming time this user has played as a COP within a [TC] CityDriving server
        /// </summary>
        public GamingTime GamingTimeCop => new GamingTime(_gamingTimeCop);

        /// <summary>
        /// Gets the total gaming time (in seconds) this user has played as a civilian within a [TC] CityDriving server
        /// </summary>
        [JsonProperty("gaming_time_civil")]
        private int _gamingTimeCivilian { get; set; }

        /// <summary>
        /// Gets the total gaming time this user has played as a civilian within a [TC] CityDriving server
        /// </summary>
        public GamingTime GamingTimeCivilian => new GamingTime(_gamingTimeCivilian);

        /// <summary>
        /// Gets the total gaming time (in seconds) this user has played as a TOW within a [TC] CityDriving server
        /// </summary>
        [JsonProperty("gaming_time_tow")]
        private int _gamingTimeTow { get; set; }

        /// <summary>
        /// Gets the total gaming time this user has played as a TOW within a [TC] CityDriving server
        /// </summary>
        public GamingTime GamingTimeTow => new GamingTime(_gamingTimeTow);

        /// <summary>
        /// Gets the total gaming time (in seconds) this user has played as a MED within a [TC] CityDriving server
        /// </summary>
        [JsonProperty("gaming_time_med")]
        private int _gamingTimeMedic { get; set; }

        /// <summary>
        /// Gets the total gaming time this user has played as a MED within a [TC] CityDriving server
        /// </summary>
        public GamingTime GamingTimeMedic => new GamingTime(_gamingTimeMedic);

        /// <summary>
        /// Gets the total gaming time (in seconds) this user has played whilst setting speedtraps as a COP
        /// </summary>
        [JsonProperty("gaming_time_speedtrapping")]
        private int _gamingTimeSpeedtrapping { get; set; }

        /// <summary>
        /// Gets the total gaming time this user has played whilst setting speedtraps as a COP
        /// </summary>
        public GamingTime GamingTimeSpeedtrapping => new GamingTime(_gamingTimeSpeedtrapping);

        /// <summary>
        /// Gets the total gaming time (in seconds) this user has played whilst chasing others as a COP
        /// </summary>
        [JsonProperty("gaming_time_chasing")]
        private int _gamingTimeChasing { get; set; }

        /// <summary>
        /// Gets the total gaming time this user has played whilst chasing others as a COP
        /// </summary>
        public GamingTime GamingTimeChasing => new GamingTime(_gamingTimeChasing);

        /// <summary>
        /// Gets the total gaming time (in seconds) this user has played whilst being chased by cops
        /// </summary>
        [JsonProperty("gaming_time_chased")]
        private int _gamingTimeChased { get; set; }

        /// <summary>
        /// Gets the total gaming time this user has played whilst being chased by cops
        /// </summary>
        public GamingTime GamingTimeChased => new GamingTime(_gamingTimeChased);

        /// <summary>
        /// Gets the total gaming time (in seconds) this user has played whilst racing
        /// </summary>
        [JsonProperty("108")]
        private int _gamingTimeRacing { get; set; }

        /// <summary>
        /// Gets the total gaming time this user has played whilst racing
        /// </summary>
        public GamingTime GamingTimeRacing => new GamingTime(_gamingTimeRacing);

        /// <summary>
        /// Gets the total distance (in meters) this user has driven as a COP
        /// </summary>
        [JsonProperty("driven_distance_cop")]
        private double _drivenDistanceCop { get; set; }

        /// <summary>
        /// Gets the total distance this user has driven as a COP
        /// </summary>
        public Distance DrivenDistanceCop => new Distance(_drivenDistanceCop, Distance.DistanceType.Meters);

        /// <summary>
        /// Gets the total distance (in meters) this user has driven as a civilian
        /// </summary>
        [JsonProperty("driven_distance_civil")]
        private double _drivenDistanceCivilian { get; set; }

        /// <summary>
        /// Gets the total distance this user has driven as a civilian
        /// </summary>
        public Distance DrivenDistanceCivilian => new Distance(_drivenDistanceCivilian, Distance.DistanceType.Meters);

        /// <summary>
        /// Gets the total distance (in meters) this user has driven as a medic
        /// </summary>
        [JsonProperty("driven_distance_med")]
        private double _drivenDistanceMedic { get; set; }

        /// <summary>
        /// Gets the total distance this user has driven as a medic
        /// </summary>
        public Distance DrivenDistanceMedic => new Distance(_drivenDistanceMedic, Distance.DistanceType.Meters);

        /// <summary>
        /// Gets the total distance (in meters) this user has driven off the main roads
        /// </summary>
        [JsonProperty("driven_distance_offroad")]
        private double _drivenDistanceOffRoad { get; set; }

        /// <summary>
        /// Gets the total distance this user has driven off the main roads
        /// </summary>
        public Distance DrivenDistanceOffRoad => new Distance(_drivenDistanceOffRoad, Distance.DistanceType.Meters);

        /// <summary>
        /// Gets the total distance (in meters) this user has driven whilst chasing others as a COP
        /// </summary>
        [JsonProperty("driven_distance_chasing")]
        private double _drivenDistanceChasing { get; set; }

        /// <summary>
        /// Gets the total distance this user has driven whilst chasing others as a COP
        /// </summary>
        public Distance DrivenDistanceChasing => new Distance(_drivenDistanceChased, Distance.DistanceType.Meters);

        /// <summary>
        /// Gets the total distance (in meters) this user has driven whilst being chased by cops
        /// </summary>
        [JsonProperty("driven_distance_chased")]
        private double _drivenDistanceChased { get; set; }

        /// <summary>
        /// Gets the total distance this user has driven whilst being chased by cops
        /// </summary>
        public Distance DrivenDistanceChased => new Distance(_drivenDistanceChased, Distance.DistanceType.Meters);

        /// <summary>
        /// Gets the total distance (in meters) this user has driven responding to SOS calls
        /// </summary>
        [JsonProperty("driven_distance_sos")]
        private double _drivenDistanceSOS { get; set; }

        /// <summary>
        /// Gets the total distance this user has driven responding to SOS calls
        /// </summary>
        public Distance DrivenDistanceSOS => new Distance(_drivenDistanceSOS, Distance.DistanceType.Meters);

        /// <summary>
        /// Gets the total distance (in meters) this user has driven whilst racing
        /// </summary>
        [JsonProperty("158")]
        private double _drivenDistanceRacing { get; set; }

        /// <summary>
        /// Gets the total distance this user has driven whilst racing
        /// </summary>
        public Distance DrivenDistanceRacing => new Distance(_drivenDistanceRacing, Distance.DistanceType.Meters);

        /// <summary>
        /// Gets the users total XP points earnt as a COP
        /// </summary>
        [JsonProperty("cop_xp")]
        public int XPCop { get; private set; }

        /// <summary>
        /// Gets the users total XP points earnt as a robber
        /// </summary>
        [JsonProperty("robber_xp")]
        public int XPRobber { get; private set; }

        /// <summary>
        /// Gets the users total XP points earnt from role play
        /// </summary>
        [JsonProperty("rp_xp")]
        public int XPRolePlay { get; private set; }

        /// <summary>
        /// Gets the users current COP rank
        /// </summary>
        [JsonProperty("211")]
        private int _copRank { get; set; }

        public CopRank CopRank => CopRanks[_copRank];

        /// <summary>
        /// Gets the total occourences this user has used a winch to assist other users as part of an SOS response
        /// </summary>
        [JsonProperty("winch_used")]
        public double WinchesUsed { get; private set; }

        /// <summary>
        /// Gets the total occourences this user has placed a ramp whilst playing as a TOW (!ramp+)
        /// </summary>
        [JsonProperty("ramps_placed")]
        public int RampsPlaced { get; private set; }

        /// <summary>
        /// Gets the total occourences this user has placed a roadblock whilst playing as a COP (!rb+)
        /// </summary>
        [JsonProperty("roadblocks_placed")]
        public int RoadblocksPlaced { get; private set; }

        /// <summary>
        /// Gets the total occourences this user has requested help via an SOS call
        /// </summary>
        [JsonProperty("sos_called")]
        public int SOSCalled { get; private set; }

        /// <summary>
        /// Gets the total occourences this user has responded to an SOS call
        /// </summary>
        [JsonProperty("sos_responded")]
        public int SOSResponded { get; private set; }

        /// <summary>
        /// Gets the total occourences this user has placed a hazard warning (!hazard)
        /// </summary>
        [JsonProperty("hazards_placed")]
        public int HazardsPlaced { get; private set; }
        #endregion

        #region Dictionaries
        /// <summary>
        /// Dictionary to hold details of each CopRank properties
        /// </summary>
        public static readonly Dictionary<int, CopRank> CopRanks = new Dictionary<int, CopRank>()
        {
            {0, new CopRank("Police Recruit", 1, 0)},
            {1, new CopRank("Police Recruit", 2, 500)},
            {2, new CopRank("Police Recruit", 3, 1040)},
            {3, new CopRank("Police Recruit", 4, 1630)},
            {4, new CopRank("Police Recruit", 5, 2270)},
            {5, new CopRank("Police Constable", 1, 2960)},
            {6, new CopRank("Police Constable", 2, 3710)},
            {7, new CopRank("Police Constable", 3, 4520)},
            {8, new CopRank("Sergeant", 1, 5400)},
            {9, new CopRank("Sergeant", 2, 6350)},
            {10, new CopRank("Sergeant", 3, 7390)},
            {11, new CopRank("Sergeant", 4, 850)},
            {12, new CopRank("Inspector", 1, 9730)},
            {13, new CopRank("Inspector", 2, 11040)},
            {14, new CopRank("Inspector", 3, 12470)},
            {15, new CopRank("Inspector", 4, 14020)},
            {16, new CopRank("Chief Inspector", 1, 15700)},
            {17, new CopRank("Chief Inspector", 2, 17530)},
            {18, new CopRank("Chief Inspector", 3, 19500)},
            {19, new CopRank("Chief Inspector", 4, 21640)},
            {20, new CopRank("Superintendent", 1, 23960)},
            {21, new CopRank("Superintendent", 2, 26480)},
            {22, new CopRank("Superintendent", 3, 29210)},
            {23, new CopRank("Superintendent", 4, 32170)},
            {24, new CopRank("Superintendent", 5, 35380)},
            {25, new CopRank("Chief Superintendent", 1, 38850)},
            {26, new CopRank("Chief Superintendent", 2, 42620)},
            {27, new CopRank("Chief Superintendent", 3, 46710)},
            {28, new CopRank("Chief Superintendent", 4, 51140)},
            {29, new CopRank("Chief Superintendent", 5, 55950)},
            {30, new CopRank("Commander", 1, 61160)},
            {31, new CopRank("Commander", 2, 66800)},
            {32, new CopRank("Commander", 3, 72930)},
            {33, new CopRank("Commander", 4, 79560)},
            {34, new CopRank("Commander", 5, 86760)},
            {35, new CopRank("Deputy Assistant Commissioner", 1, 94560)},
            {36, new CopRank("Deputy Assistant Commissioner", 2, 103020)},
            {37, new CopRank("Deputy Assistant Commissioner", 3, 112190)},
            {38, new CopRank("Deputy Assistant Commissioner", 4, 122140)},
            {39, new CopRank("Deputy Assistant Commissioner", 5, 132920)},
            {40, new CopRank("Assistant Commissioner", 1, 144600)},
            {41, new CopRank("Assistant Commissioner", 2, 157270)},
            {42, new CopRank("Assistant Commissioner", 3, 171010)},
            {43, new CopRank("Assistant Commissioner", 4, 185910)},
            {44, new CopRank("Assistant Commissioner", 5, 202050)},
            {45, new CopRank("Deputy Commissioner", 1, 219560)},
            {46, new CopRank("Deputy Commissioner", 2, 238540)},
            {47, new CopRank("Deputy Commissioner", 3, 259110)},
            {48, new CopRank("Deputy Commissioner", 4, 281420)},
            {49, new CopRank("Deputy Commissioner", 5, 305610)},
            {50, new CopRank("Commissioner", 1, 311830)},
            {51, new CopRank("Commissioner", 2, 360260)},
            {52, new CopRank("Commissioner", 3, 391080)},
            {53, new CopRank("Commissioner", 4, 424500)},
            {54, new CopRank("Commissioner", 5, 460720)},
            {55, new CopRank("Commissioner", 6, 500000)},
            {56, new CopRank("Commissioner", 7, 542590)},
            {57, new CopRank("Commissioner", 8, 588750)}
        };
        #endregion
    }
}
