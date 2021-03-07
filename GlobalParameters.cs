using System;

namespace TCGaming.NET
{
    public abstract class GlobalParameters
    {
        #region Private Fields
        /// <summary>
        /// Number of rows to return in queries which return collections
        /// </summary>
        private int _rows = 20;

        /// <summary>
        /// Number of rows to skip before returning data in queries which return collections
        /// </summary>
        private int _rowsToSkip = 0;
        #endregion

        #region Methods
        /// <summary>
        /// Chaining method to set the number of rows to be returned by the GetData method.
        /// </summary>
        /// <param name="rowCount">Min 0, Max 1000</param>
        /// <returns>GlobalParameters object</returns>
        public GlobalParameters GetRows(int rowCount)
        {
            this._rows = rowCount;
            return this;
        }

        /// <summary>
        /// Chaining method to set the number of rows to be skipped by the GetData method.
        /// </summary>
        /// <param name="rowCount">Min 0, Max 1000</param>
        /// <returns>GlobalParameters object</returns>
        public GlobalParameters SkipRows(int rowCount)
        {
            this._rowsToSkip = rowCount;
            return this;
        }

        /// <summary>
        /// Returns the results set
        /// </summary>
        public virtual void GetData() { }
        #endregion

        #region Properties
        /// <summary>
        /// Gets/Sets the number of objects to be returned in the collection. Min 0, Max 1000
        /// </summary>
        public int RowsToReturn
        {
            get
            {
                return _rows;
            }
            set
            {
                if (value < 0 || value > 1000)
                {
                    throw new ArgumentOutOfRangeException("RowsToReturn", "Please enter a valid number between 0 and 1000");
                }
                else
                {
                    _rows = value;
                }
            }
        }

        /// <summary>
        /// Gets/Sets the number of objects to be skipped before being returned in the collection. Min 0, Max 1000
        /// </summary>
        public int RowsToSkip
        {
            get
            {
                return _rowsToSkip;
            }
            set
            {
                if (value < 0 || value > 1000)
                {
                    throw new ArgumentOutOfRangeException("RowsToSkip", "Please enter a valid number between 0 and 1000");
                }
                else
                {
                    _rows = value;
                }
            }
        }
        #endregion
    }
}
