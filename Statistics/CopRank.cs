namespace TCGaming.NET.Statistics
{
    public class CopRank
    {
        #region Constructors
        /// <summary>
        /// New instance of a CopRank
        /// </summary>
        /// <param name="name">Name of the rank</param>
        /// <param name="level">Level of the rank</param>
        /// <param name="xp">Minimum XP required to gain rain</param>
        public CopRank(string name, int level, int xp)
        {
            Name = name;
            Level = level;
            XP = xp;
        }
        #endregion

        #region Fields
        /// <summary>
        /// Name of the Rank
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Level of the rank
        /// </summary>
        public int Level { get; private set; }

        /// <summary>
        /// Minimum XP required to gain rank
        /// </summary>
        public int XP { get; private set; }
        #endregion
    }
}