using Garage1._0;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Garage1._0Tests
{
    [TestClass]

    public class GarageTests
    {
        
        private Garage<Vehicle> garage;
        private GarageManager garageM;
        public TestContext TestContext { get; set; }

        //[ClassInitialize]
        //public static void ClassSeedDataVehicle()
        //{

        //}
       
        [TestInitialize]
        public void SetUp()
        {
            if (TestContext.TestName.EndsWith("0"))
            {

                garage = new Garage<Vehicle>(0);
                garageM = new GarageManager(0);
            }
            else
            {

                garage = new Garage<Vehicle>(3);
                garageM = new GarageManager(3);
            }

            //if(TestContext.TestName.EndsWith("ben"))
            //{
            //    garage.Add(new Car("abc123", "white", 2, "bensin"));

            //}

            //else if (TestContext.TestName.EndsWith("3"))
            //{
            //    garage.Add(new Car("abc123", "white", 2, "bensin"));
            //    garage.Add(new Airplane("abc123", "white", 2, 3));
            //    garage.Add(new Bus("abc123", "white", 2, 3));

            //}

            //var vehicles = new Garage<Vehicle>(3)
            //{
            //    new Car("abc123", "white", 2, "bensin"),
            //    new Airplane("abc123", "white", 2, 3),
            //    new Bus("abc123", "white", 2, 3)
            //};
        }

        [TestMethod]
        public void CheckDefaultCapacity()
        {
            //Arrange
            const int expected = 3;
            var garage = new Garage<Vehicle>(expected);
            //Act
            //var tryToAdd = garage.Add(new Car("abc123", "white", 2, "bensin"));
            //int count = garage.Count;
            int actual = garage.Capacity;
            //Assert
            //Assert.AreEqual(actual, expected);
            //Assert.IsFalse(tryToAdd);
            //Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected, actual);
            

        }
        [TestMethod]
        public void CheckCountVehicles()
        {
            var expected = 2;
            //skapa 2 fordon löst
            var airplane = garage.Add(new Airplane("abc123", "white", 2, 3));
            var car = garage.Add(new Car("abc124", "white", 2, "diesel"));
            //lägg till dem i garaget


            
            //var addToGarage = airplane;
            // var actual som är count
            var actual = garage.Count++;
            //assert are equal
            Assert.IsTrue(airplane);
            Assert.IsTrue(car);
            Assert.AreEqual(expected, actual);
        }
       
        [TestMethod]
        public void AddVeicleToGarageTest()
        {


            var airplane = new Airplane("abc123", "white", 2, 3);
            var addVehicle = garage.Add(airplane);
            var findVehicle = garage.Vehicles[0];

            //Act
            //var removeItem = garage.RemoveItem(index);

            Assert.AreEqual(airplane, findVehicle);
           //Assert.IsTrue(addVehicle);
        }
    }
}
