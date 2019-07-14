using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VMS.Entities;
using VMS.Models;

namespace VMS.Interfaces
{
    public interface IService
    {
        IEnumerable<VehicleTypeModel> GetVehicleTypes();
        void CreateCar(Car car);
        IEnumerable<Car> GetAllCars();
    }
}
