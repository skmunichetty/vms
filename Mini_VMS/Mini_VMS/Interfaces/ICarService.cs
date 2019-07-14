using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VMS.Entities;
using VMS.Services;

namespace VMS.Interfaces
{
    public interface ICarService : IVehicleService<Car>
    {
        void Create(Car vehicle);
        IEnumerable<Car> GetAllCars();
    }
}
