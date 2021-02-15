using Garage1._0;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Garage1._0Tests
{
    [TestClass]

    public class GarageTests
    {
        
        private Garage<Vehicle> garage;
        public TestContext TestContext { get; set; }


        [TestInitialize]
        public void SetUp()
        {
            if (TestContext.TestName.EndsWith("0"))
            {

                garage = new Garage<Vehicle>(0);
           
            }
            else
            {

                garage = new Garage<Vehicle>(3);
 
            }

        }

        [TestMethod]
        public void CheckDefaultCapacity()
        {
  
            const int expected = 3;
            var garage = new Garage<Vehicle>(expected);
         
            int actual = garage.Capacity;

            Assert.AreEqual(expected, actual);
            

        }
        [TestMethod]
        public void CheckCountVehiclesTest()
        {
            var expected = 2;
          
            var airplane = garage.Add(new Airplane("abc123", "white", 2, 3));
            var car = garage.Add(new Car("abc124", "white", 2, "diesel"));
            
            var actual = garage.Count;
            //assert are equal
            Assert.IsTrue(airplane);
            Assert.IsTrue(car);
            Assert.AreEqual(expected, actual);
        }
       
        [TestMethod]
        public void AddVeicleToGarageTest_()
        {
            var airplane = new Airplane("abc123", "white", 2, 3);
            var addVehicle = garage.Add(airplane);
            var findVehicle = garage.Vehicles[0];
            Assert.AreEqual(airplane, findVehicle);
   
        }

        //Den här testmetoden fick mig äntlien att förstå hur testen fungerar och varför det är så bra. Den hjälpte mig att fixa ett fel i koden :D
        [TestMethod]
        public void CheckAddadVehiclesLeftTest_CapacityMinusCount()
        {
            int expected = 1;
            
            var airplane = garage.Add(new Airplane("abc123", "white", 2, 3));
            var car = garage.Add(new Car("abc124", "white", 2, "diesel"));
            
            int actual = garage.Capacity - garage.Count;

            
            Assert.IsTrue(airplane);
            Assert.IsTrue(car);
            Assert.AreEqual(expected, actual);

        }
    }
}
