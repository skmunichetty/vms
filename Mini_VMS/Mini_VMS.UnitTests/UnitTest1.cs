using System;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mini_VMS.Services;
using Moq;
using VMS.Entities;
using VMS.Interfaces;

namespace Mini_VMS.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private Car carModel = new Car
        {
            BodyTypeId = 1,
            Wheels = 4,
            Doors = 4,
            Engine = "V6",
            Model = "City",
            Make="Honda",
            VehicleTypeId = 1
        };

        [TestMethod]
        public void should_throw_error_if_the_object_is_null()
        {
            try
            {
                Car car = null;
                Mock<IDistributedCache> _mockDistributedCache = new Mock<IDistributedCache>();

                var _carService = new CarService(_mockDistributedCache.Object);
                _carService.Create(car);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Cannot insert null");
            }
        }

        [TestMethod]
        public void should_throw_error_if_the_bodytypeid_is_invalid()
        {
            try
            {
                Mock<IDistributedCache> _mockDistributedCache = new Mock<IDistributedCache>();
                var _carService = new CarService(_mockDistributedCache.Object);

                carModel.BodyTypeId = 123;
                _carService.Create(carModel);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Invalid BodyType");
            }
        }

        [TestMethod]
        public void should_throw_error_if_the_make_is_empty()
        {
            try
            {
                Mock<IDistributedCache> _mockDistributedCache = new Mock<IDistributedCache>();
                var _carService = new CarService(_mockDistributedCache.Object);

                carModel.Make = String.Empty;
                _carService.Create(carModel);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Make cannot be empty");
            }
        }

        [TestMethod]
        public void should_throw_error_if_the_engine_is_empty()
        {
            try
            {
                Mock<IDistributedCache> _mockDistributedCache = new Mock<IDistributedCache>();
                var _carService = new CarService(_mockDistributedCache.Object);

                carModel.Engine = String.Empty;
                _carService.Create(carModel);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Engine cannot be empty");
            }
        }

        [TestMethod]
        public void should_throw_error_if_the_model_is_empty()
        {
            try
            {
                Mock<IDistributedCache> _mockDistributedCache = new Mock<IDistributedCache>();
                var _carService = new CarService(_mockDistributedCache.Object);

                carModel.Model = String.Empty;
                _carService.Create(carModel);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Model cannot be empty");
            }
        }

        [TestMethod]
        public void should_throw_error_if_the_vehicletype_is_invalid()
        {
            try
            {
                Mock<IDistributedCache> _mockDistributedCache = new Mock<IDistributedCache>();
                var _carService = new CarService(_mockDistributedCache.Object);

                carModel.VehicleTypeId = 1231;
                _carService.Create(carModel);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Invalid VehicleType");
            }
        }

        [TestMethod]
        public void should_succeed_if_the_object_is_valid()
        {
            try
            {
                Mock<IDistributedCache> _mockDistributedCache = new Mock<IDistributedCache>();
                var _carService = new CarService(_mockDistributedCache.Object);
                
                _carService.Create(carModel);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Invalid VehicleType");
            }
        }

    }
}
