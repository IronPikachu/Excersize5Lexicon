using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excersize_5_Lexicon.Garages;
using Excersize_5_Lexicon.Vehicles;
using System.Collections.Generic;
using System;

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
        bool actualAdd = garage.AddVehicle(car);

        //Assert
        Assert.IsTrue(actualAdd);
        Assert.AreEqual(expectedParkedVehicles, garage.ParkedVehicles);
        Assert.AreEqual(expectedFreeParkingSpots, garage.FreeParkingSpots);

    }
    [TestMethod]
    public void ForeachIterate_GarageIterateVehiclesInititateWithParams_Success()
    {
        //Arrange
        Car car1 = new Car("COOL", "Olle Svensson", "Yellow", 4, 20000, "Audi");
        Car car2 = new Car("ABC123", "Pelle Jönsson", "Red", 4, 10000, "Volvo");
        Car car3 = new Car("XYZ789", "Göran Persson", "Black", 4, 200000, "Ferarri");
        Car[] cars = {car1, car2, car3};
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
    [TestMethod]
    public void RemoveVehicle_RemoveUnicycle_Success()
    {
        //Arrange
        Unicycle unicycle1 = new Unicycle("lOl", "Berta", "Black", 1, 1500, 123.5);
        Unicycle unicycle2 = new Unicycle("Joxe", "Erik", "Red", 1, 1499, 150);
        Unicycle unicycle3 = new Unicycle("123abc", "Ragnar", "Pink", 1, 899, 80.12);
        Unicycle unicycle4 = new Unicycle("abc321", "Clown-Sture", "Purple", 1, 10000, 1123.5);
        Unicycle unicycle5 = new Unicycle("hahaha", "Svenjamin", "Green", 1, 1505, 120);
        Unicycle[] unicycles = {unicycle1, unicycle2, unicycle3, unicycle4, unicycle5};
        Garage<Unicycle> garage = new Garage<Unicycle>("Cirkus-Martinas Enhjulings Verkstad", 20, unicycles);

        //Act
        bool actualValue = garage.RemoveVehicle(unicycle3);
        bool actualExists = garage.VehicleExists(unicycle3);

        //Assert
        Assert.IsTrue(actualValue);
        Assert.IsFalse(actualExists);

    }
    [TestMethod]
    public void AddVehicle_AddOnFullContainer_Failure()
    {
        //Arrange
        Airplane airplane1 = new Airplane("123f45f", "Hasse", "White", 6, 120000, 22.5);
        Airplane airplane2 = new Airplane("189g69f", "Bosse", "White", 6, 120500, 26.5);
        Airplane[] airplanes = { airplane1, airplane2 };
        Garage<Airplane> garage = new Garage<Airplane>("Flygplats", 2, airplanes);

        //Act
        Airplane airplane3 = new Airplane("987k25i", "Nisse", "Gray", 6, 120000, 22.5);
        bool actualValue = garage.AddVehicle(airplane3);

        //Assert
        Assert.IsFalse(actualValue);

    }
    [TestMethod]
    public void VehicleExists_CheckExistent_Success()
    {
        //Arrange
        Car car1 = new Car("oij589", "Olof Palme", "White", 5, 1250000, "Porsche");
        Garage<Car> garage = new Garage<Car>("Linus Mecharstad", 3, car1);

        //Act
        Car testCar = car1;
        bool actualValue = garage.VehicleExists(testCar);

        //Assert
        Assert.IsTrue(actualValue);

    }
    [TestMethod]
    public void VehicleExists_CheckNonExistent_Failure()
    {
        //Arrange
        Car car1 = new Car("oij589", "Olof Palme", "White", 5, 1250000, "Porsche");
        Garage<Car> garage = new Garage<Car>("Linus Mecharstad", 3, car1);

        //Act
        Car testCar = new Car("abc321", "Linda Palme", "Black", 3, 1250, "Golf");
        bool actualValue = garage.VehicleExists(testCar);

        //Assert
        Assert.IsFalse(actualValue);

    }
    [TestMethod]
    public void RemoveVehicle_RemoveNonExistent_Failure()
    {
        //Arrange
        Car car1 = new Car("oij589", "Olof Palme", "White", 5, 1250000, "Porsche");
        Garage<Car> garage = new Garage<Car>("Linus Mecharstad", 3, car1);

        //Act
        Car testCar = new Car("abc321", "Linda Palme", "Black", 3, 1250, "Golf");
        bool actualValue = garage.RemoveVehicle(testCar);

        //Assert
        Assert.IsFalse(actualValue);
        Assert.AreEqual(3, garage.MaxCapacity);
        Assert.AreEqual(1, garage.ParkedVehicles);
        Assert.AreEqual(2, garage.FreeParkingSpots);

    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void PropertyName_InputNull_CriticalFailure()
    {
        //Arrange
        string? name = null;
        int capacity = 0;

        //Act
        Garage<Vehicle> garage = new Garage<Vehicle>(name!, capacity);

        //Assert
    }
}
