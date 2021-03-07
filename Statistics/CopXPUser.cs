using System.Linq;

namespace TCGaming.NET.Statistics
{
    /// <summary>
    /// Base statistics with Value data
    /// </summary>
    public class CopXPUser : BaseUserWithValue
    {
        #region Constructors
        /// <summary>
        /// New instance of an CopXP object
        /// </summary>
        protected CopXPUser()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the CopRank object of the user
        /// </summary>
        public CopRank CopRank => UserProfile.Stats.CopRanks.Where(x => x.Value.XP <= Value).LastOrDefault().Value;
        #endregion
    }
}
