using Garage_Ö5;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage_Ö5.Tests
{
    [TestClass()]
    public class OprationsTests
    {
        private Garage<Vehicle> garage;

        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void GarageAddVehicle(TestContext context)
        {
          
        }

        [TestInitialize]
        public void SetUp()
        {
            garage = TestContext.TestName.EndsWith('0') ? new Garage<Vehicle>(0,"garage") : new Garage<Vehicle>(8, "garage");

            if (TestContext.TestName.EndsWith('1'))
            {
                garage.Add(new Car("car123", "Red", 3, 3));
            }
            else if (TestContext.TestName.EndsWith('3')) {

                garage.Add(new Car("car123", "Red", 4, 3));
                garage.Add(new Boat("boat123", "Red", 2, 3.1));
                garage.Add(new Bus("bus123", "yellow", 8, 3));

            }

        }

        [TestMethod]
        public void RemoveTestList1()
        {
            //Arrange
            const int index = 1;
            //Act
            var removeCar = garage.RemoveItem(index);

            //Assert
            Assert.IsTrue(removeCar);
        }

        [TestMethod]
        public void CountNotNullItems3()
        {
            //Arrange
            const int expected = 3;
            //Act
            var vehicleNumber = garage.Counter();

            //Assert
            Assert.AreEqual(expected, vehicleNumber);
        }


        [TestMethod]
        public void SearchOnRedVehicle3()
        {
            //Arrange
            const int expected = 2;
            string type = " ";
            string color = "red";
            int wheels = -1;

            //Act
            var redVeh = garage.SearchOnVehicle(type, color, wheels);
            var numberOfRedVe = redVeh.Count;

            //Assert
            Assert.AreEqual(expected, numberOfRedVe);
        }

        [TestMethod]
        public void AddVehToGarageCapacity0()
        {
            //Arrange
            const int expected = 0;

            //Act
            var addTest = garage.Add(new Car("car123", "Red", 3, 3));
            var actual = garage.vehLenght;
    

            //Assert
            Assert.IsFalse(addTest);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddVehToGarageCapacity8()
        {
            //Arrange
            const int expected = 8;
            //Act
            var addTest = garage.Add(new Car("car123", "Red", 3, 3));
            var actual = garage.vehLenght;
            //Assert
            Assert.IsTrue(addTest);
            Assert.AreEqual(expected, actual);
        }


        public interface IMyCollection : IEnumerable<Vehicle>
        {
        }

        [TestMethod]
        [Obsolete]
        public void TestList()
        {
            var mock = new Mock<IMyCollection>(MockBehavior.Strict);
            mock.Setup(m => m.GetEnumerator()).Returns(VehicleList());

            var size = mock.Object.Count();

            Assert.AreEqual(1, size);
        }

        public IEnumerator<Vehicle> VehicleList()
        {
            yield return new Car("car123", "red", 4, 12) { RegistreringNum = "car123", Color = "red", WheelsNum = 4, Cylinder = 12 };
        }


        [ClassCleanup]
        public static void GarageCleanUp()
        {

        }
    }
}