using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VMS.Entities;
using VMS.Interfaces;

namespace VMS.Services
{
    public abstract class VehicleService<T> : IVehicleService<T>
    {
        public abstract void Create(T vehicle);
    }
}
