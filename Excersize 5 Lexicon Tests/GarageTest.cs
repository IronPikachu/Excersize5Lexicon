using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excersize_5_Lexicon.Garages;
using Excersize_5_Lexicon.Vehicles;
using System.Collections.Generic;

/* Use Arrange -> Act -> Assert
 * Good names for methods, like [MethodName_StateUnderTest_ExpectedBehavior]
 */

namespace Excersize_5_Lexicon_Tests;

[TestClass]
public class GarageTest
{
/*  Template
    [TestMethod]
    public void MethodName_StateUnderTest_ExpectedBehavior()
    {
        //Arrange

        //Act

        //Assert

    }
*/
    [TestMethod]
    public void ConstructorAndPropertys_InitiateWithoutParams_Success()
    {
        //Arrange
        int size = 2;
        string name = "Olles Byggverkstad";
        int parkedVehicles = 0;
        int freeParkingSpots = size;

        //Act
        Garage<Vehicle> garage = new Garage<Vehicle>(name, size);

        //Assert
        Assert.AreEqual(name, garage.Name);
        Assert.AreEqual(size, garage.MaxCapacity);
        Assert.AreEqual(parkedVehicles, garage.ParkedVehicles);
        Assert.AreEqual(freeParkingSpots, garage.FreeParkingSpots);
    }
    [TestMethod]
    public void AddVehicle_Car_Success()
    {
        //Arrange
        Garage<Vehicle> garage = new Garage<Vehicle>("Olles Byggverkstad", 5);
        Car car = new Car("abc123", "Göran Persson", "red", 4, 20000, "Volvo");
        int expectedParkedVehicles = 1;
        int expectedFreeParkingSpots = 5 - expectedParkedVehicles;

        //Act
        garage.AddVehicle(car);

        //Assert
        Assert.AreEqual(car, garage.GetListVehicles()[0]);
        Assert.AreEqual(expectedParkedVehicles, garage.ParkedVehicles);
        Assert.AreEqual(expectedFreeParkingSpots, garage.FreeParkingSpots);

    }
    [TestMethod]
    public void ForeachIterate_GarageIterateVehicles_Success()
    {
        //Arrange
        Vehicle car1 = new Car("COOL", "Olle Svensson", "Yellow", 4, 20000, "Audi");
        Vehicle car2 = new Car("ABC123", "Pelle Jönsson", "Red", 4, 10000, "Volvo");
        Vehicle car3 = new Car("XYZ789", "Göran Persson", "Black", 4, 200000, "Ferarri");
        Vehicle[] cars = {car1, car2, car3};
        Garage<Car> garage = new Garage<Car>("Nisses Bilverkstad", 5, cars);

        //Act
        List<Vehicle> expected = new List<Vehicle> { car1, car2, car3 };
        List<Vehicle> actual = new List<Vehicle>();
        foreach (Car car in garage)
        {
            actual.Add(car);
        }

        //Assert
        Assert.AreEqual(expected[0], actual[0]);
        Assert.AreEqual(expected[1], actual[1]);
        Assert.AreEqual(expected[2], actual[2]);
    }
}
