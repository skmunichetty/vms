using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FluentCache;
using Microsoft.Extensions.Caching.Distributed;
using Mini_VMS.Helpers;
using Newtonsoft.Json;
using Serilog;
using StackExchange.Redis;
using VMS.Entities;
using VMS.Interfaces;
using VMS.Services;

namespace Mini_VMS.Services
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

                //_distributedCache.SetStringAsync("dc+" + car.Id, data).Wait();
                SaveToRedisCache(car);

            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw ex;
            }
        }
        
        public void SaveToRedisCache(Car car)
        {
            var data = JsonConvert.SerializeObject(car);

            var carKeyStore = _distributedCache.GetString("car");

            carKeyStore += car.Id + ":";

            _distributedCache.SetStringAsync(car.Id, data).Wait();
            _distributedCache.SetStringAsync("car", carKeyStore).Wait();

        }

        public IEnumerable<Car> GetAllCars()
        {
            try
            {
                var result = new List<Car>();

                var carIdValue = _distributedCache.GetString("car");
                var ids = carIdValue.Split(':');
                foreach (var id in ids)
                {
                    if (!String.IsNullOrEmpty(id))
                    {
                        var bytes = _distributedCache.Get(id);
                        var cardata = System.Text.Encoding.UTF8.GetString(bytes);
                        var car = JsonConvert.DeserializeObject<Car>(cardata);
                        result.Add(car);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw ex;
            }
        }

    }
}
