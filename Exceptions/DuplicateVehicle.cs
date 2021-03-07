using System;

namespace TCGaming.NET
{
    /// <summary>
    /// DuplicateVehicle Exception
    /// </summary>
    public class DuplicateVehicleException : Exception
    {
        /// <summary>
        /// New DuplicateVehicleException
        /// </summary>
        public DuplicateVehicleException()
        {

        }

        /// <summary>
        /// New DuplicateVehicleException
        /// </summary>
        /// <param name="vin">Vehicles VIN (Vehicle Identification Number)/param>
        public DuplicateVehicleException(string vin) : base($"This vehicle already exists in the collection: '{vin}'")
        {

        }
    }
}
