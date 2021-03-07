using System;

namespace TCGaming.NET
{
    public class UnknownVehicleException : Exception
    {
        /// <summary>
        /// New VehicleNotFound Exception
        /// </summary>
        public UnknownVehicleException()
        {

        }

        /// <summary>
        /// New VehicleNotFouond Exception
        /// </summary>
        /// <param name="model">Vehicle model (3 character code)</param>
        public UnknownVehicleException(string model) : base($"Unrecognised vehicle model was passed: '{model}'")
        {

        }
    }
}
