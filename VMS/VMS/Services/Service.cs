using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VMS.Entities;
using VMS.Enums;
using VMS.Helpers;
using VMS.Interfaces;
using VMS.Models;

namespace VMS.Services
{
    public class Service: IService
    {
        private readonly ICarService _carService;
        public Service(ICarService carService)
        {
            _carService = carService;
        }

        public IEnumerable<VehicleTypeModel> GetVehicleTypes()
        {
            try
            {
                var result = new List<VehicleTypeModel>();
                var vehicleTypes = Enum.GetValues(typeof(VehicleTypes));
                foreach(var vt in vehicleTypes)
                {
                    result.Add(new VehicleTypeModel
                    {
                        Name = vt.ToString(),
                        Id = (int)vt
                    });
                }
                return result;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            
        }
                
        public void CreateCar(Car car)
        {
            try
            {
                _carService.Create(car);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw ex;
            }
        }
    }
}
