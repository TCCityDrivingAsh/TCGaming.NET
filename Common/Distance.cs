using System;

namespace TCGaming.NET.Common
{
    /// <summary>
    /// Data relative to distances
    /// </summary>
    public class Distance
    {
        #region Constructors
        /// <summary>
        /// New instance of Distance
        /// </summary>
        /// <param name="distance">Distance in meters</param>
        public Distance(double distance, DistanceType type = DistanceType.Meters)
        {
            if (type == DistanceType.Meters)
            {
                _drivenDistance = distance;
            }
            else if (type == DistanceType.Kilometers)
            {
                _drivenDistance = distance * 1000;
            }
            else
            {
                throw new ArgumentException("Invalid unit of measurement provided");
            }
        }
        #endregion

        #region Private Fields
        /// <summary>
        /// Driven distance in meters
        /// </summary>
        private double _drivenDistance;
        #endregion

        #region Properties
        /// <summary>
        /// Driven distance in Kilometers
        /// </summary>
        public double Kilmoeters => _drivenDistance / 1000;

        /// <summary>
        /// Driven distance in Miles
        /// </summary>
        public double Miles => _drivenDistance / 1609.344;

        /// <summary>
        /// Driven distance in Yards
        /// </summary>
        public double Yards => _drivenDistance / 0.9144;

        /// <summary>
        /// Driven distance in Meters
        /// </summary>
        public double Meters => _drivenDistance;
        #endregion

        #region Enums
        /// <summary>
        /// Units of measurement
        /// </summary>
        public enum DistanceType
        {
            Meters,
            Kilometers
        }
        #endregion
    }
}
