using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.Entities;
using VMS.Helpers;
using VMS.Interfaces;

namespace VMS.Services
{
    public class CarService : VehicleService<Car>, ICarService
    {
        private readonly IDistributedCache _distributedCache;

        public CarService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public override void Create(Car car)
        {
            try
            {
                if (car == null)
                    throw new Exception("Cannot insert null");

                car.Id = Guid.NewGuid().ToString();

                Helper.ValidateCar(car);

                var redis = StackExchange.Redis.ConnectionMultiplexer.Connect("localhost");
                var db = redis.GetDatabase();

                var data = JsonConvert.SerializeObject(car);
                var bytes = Encoding.UTF8.GetBytes(data);
                db.StringSet(car.Id, bytes);
                //_distributedCache.SetStringAsync("dc+" + car.Id, data).Wait();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
