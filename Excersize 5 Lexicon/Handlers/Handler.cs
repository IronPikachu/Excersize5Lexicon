using Excersize_5_Lexicon.Garages;
using Excersize_5_Lexicon.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Excersize_5_Lexicon.Handlers;

public class Handler<T> : IHandler<T> where T : IVehicle
{
    //Fields
    private IGarage<T> garage;

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



        return null;
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