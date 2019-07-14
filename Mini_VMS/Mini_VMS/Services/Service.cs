using System;
using System.Collections.Generic;
using System.ComponentModel;
using Serilog;
using VMS.Entities;
using VMS.Enums;
using VMS.Interfaces;
using VMS.Models;

namespace Mini_VMS.Services
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

        public IEnumerable<Car> GetAllCars()
        {
            return _carService.GetAllCars();
        }
    }
}
