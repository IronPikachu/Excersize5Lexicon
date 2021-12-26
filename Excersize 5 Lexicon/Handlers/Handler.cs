using Excersize_5_Lexicon.Garages;
using Excersize_5_Lexicon.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Excersize_5_Lexicon.Handlers;

public class Handler<T> : IGarage<T> where T : IVehicle
{
    //Fields
    private Garages.IGarage<T> garage;

    //Propertys
    public string GarageName { get { return garage.Name; } }
    public int MaxCapacity { get { return garage.MaxCapacity; } }

    //Constructors
    public Handler(string garageName, int garageSpace)
    {
        try
        {
            garage = new Garage<T>(garageName, garageSpace);
        }
        catch (ArgumentNullException e)
        {
            throw e;
        }
    }

    //Public Methods
    public bool AddVehicle(IVehicle vehicle)
    {
        return garage.AddVehicle((T)vehicle);
    }

    public bool RemoveVehicle(IVehicle vehicle)
    {
        return garage.RemoveVehicle((T)vehicle);
    }

    public bool VehicleExists(IVehicle vehicle)
    {
        return garage.VehicleExists((T)vehicle);
    }

    public string GetRegistryNumber()
    {
        foreach(var vehicle in garage)
        {
            yield return vehicle.RegistryNumber;
        }
    }

    public string GetOwner()
    {
        foreach (var vehicle in garage)
        {
            yield return vehicle.OwnerName;
        }
    }

    public string GetColor()
    {
        foreach (var vehicle in garage)
        {
            yield return vehicle.Color;
        }
    }

    public int GetWheelAmount()
    {
        foreach (var vehicle in garage)
        {
            yield return vehicle.AmountOfWheels;
        }
    }

    public int GetPrice()
    {
        foreach (var vehicle in garage)
        {
            yield return vehicle.Price;
        }
    }

    public Type GetGenericType()
    {
        return typeof(T);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return garage.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    //Private Methods


    //Destructors
}