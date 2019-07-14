using System;
using System.Collections.Generic;
using System.Linq;
using VMS.Entities;
using VMS.Enums;
using VMS.Models;

namespace Mini_VMS.Helpers
{
    public static class Helper
    {
        public static void ValidateCar(Car car)
        {
            //bodyType(hatchback, sedan etc)
            // Validate BodyType 
            var bodyTypes = GetBodyTypes();
            var carBodyType = bodyTypes.FirstOrDefault(x => x.Id == car.BodyTypeId);
            if (carBodyType == null)
                throw new Exception("Invalid BodyType");

            if (String.IsNullOrEmpty(car.Engine))
                throw new Exception("Engine cannot be empty");

            if (String.IsNullOrEmpty(car.Make))
                throw new Exception("Make cannot be empty");

            if (String.IsNullOrEmpty(car.Model))
                throw new Exception("Model cannot be empty");

            var vehicleTypes = GetVehicleTypes();
            var vehicleType = vehicleTypes.FirstOrDefault(x => x.Id == car.VehicleTypeId);
            if (vehicleType == null)
                throw new Exception("Invalid VehicleType");

        }

        public static IEnumerable<IdAndNameModel> GetBodyTypes()
        {
            var result = new List<IdAndNameModel>();
            var vehicleTypes = Enum.GetValues(typeof(BodyTypes));
            foreach (var vt in vehicleTypes)
            {
                result.Add(new IdAndNameModel
                {
                    Name = vt.ToString(),
                    Id = (int)vt
                });
            }
            return result;
        }

        public static IEnumerable<IdAndNameModel> GetVehicleTypes()
        {
            var result = new List<IdAndNameModel>();
            var vehicleTypes = Enum.GetValues(typeof(VehicleTypes));
            foreach (var vt in vehicleTypes)
            {
                result.Add(new IdAndNameModel
                {
                    Name = vt.ToString(),
                    Id = (int)vt
                });
            }
            return result;
        }
    }
}
