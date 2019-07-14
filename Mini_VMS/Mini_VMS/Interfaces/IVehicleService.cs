using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VMS.Interfaces
{
    public interface IVehicleService<T>
    {
        void Create(T vehicle);
    }
}
