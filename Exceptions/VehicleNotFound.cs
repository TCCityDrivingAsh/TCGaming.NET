using System;

namespace TCGaming.NET
{
    public class VehicleNotFoundException : Exception
    {
        /// <summary>
        /// New VehicleNotFound Exception
        /// </summary>
        public VehicleNotFoundException()
        {

        }

        /// <summary>
        /// New VehicleNotFouond Exception
        /// </summary>
        /// <param name="VIN">Vehicle VIN (Vehicle Identification Number)</param>
        public VehicleNotFoundException(string VIN) : base($"Could not find this vehicle: '{VIN}'")
        {

        }
    }
}
