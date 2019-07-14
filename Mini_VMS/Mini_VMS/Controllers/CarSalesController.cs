using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Mini_VMS.Helpers;
using VMS.Entities;
using VMS.Interfaces;
using VMS.Models;

namespace Mini_VMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarSalesController : ControllerBase
    {
        private readonly IService _service;

        public CarSalesController(IService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetVehicles")]
        public ApiResult<IEnumerable<VehicleTypeModel>> GetVehicles()
        {
            try
            {
                var vehicleTypes = _service.GetVehicleTypes();
                return new ApiResult<IEnumerable<VehicleTypeModel>>
                {
                    IsValid = true,
                    ReturnValue = vehicleTypes
                };
            }
            catch (Exception ex)
            {
                return new ApiResult<IEnumerable<VehicleTypeModel>>
                {
                    IsValid = false,
                    ErrorMessage = ex.Message
                };
            }
        }

        [HttpGet]
        [Route("GetBodyTypes")]
        public ApiResult<IEnumerable<IdAndNameModel>> GetBodyTypes()
        {
            try
            {
                var bodyTypes = Helper.GetBodyTypes();
                return new ApiResult<IEnumerable<IdAndNameModel>>
                {
                    IsValid = true,
                    ReturnValue = bodyTypes
                };
            }
            catch (Exception ex)
            {
                return new ApiResult<IEnumerable<IdAndNameModel>>
                {
                    IsValid = false,
                    ErrorMessage = ex.Message
                };
            }
        }

        [HttpPost]
        [Route("CreateCar")]
        public ApiResult<bool> CreateCar(Car car)
        {
            try
            {
                _service.CreateCar(car);
                return new ApiResult<bool>
                {
                    IsValid = true,
                    ReturnValue = true
                };
            }
            catch (Exception ex)
            {
                return new ApiResult<bool>
                {
                    IsValid = false,
                    ReturnValue = false,
                    ErrorMessage = ex.Message
                };
            }
        }

        [HttpGet]
        [Route("GetAllCars")]
        public ApiResult<IEnumerable<Car>> GetAllCars()
        {
            try
            {
                var cars = _service.GetAllCars();
                return new ApiResult<IEnumerable<Car>>
                {
                    IsValid = true,
                    ReturnValue = cars
                };
            }
            catch (Exception ex)
            {
                return new ApiResult<IEnumerable<Car>>
                {
                    IsValid = false,
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}