using Excersize_5_Lexicon.Vehicles;
using System.Collections;

namespace Excersize_5_Lexicon.Garages;

public class Garage<T> : IGarage<T> where T : Vehicle
{
    //Fields
    private int maxCapacity;
    private int parkedVehicles;
    private int freeParkingSpots;
    private string name;
    private Vehicle[] vehicles;

    //Propertys
    public int MaxCapacity { get { return maxCapacity; } private set { maxCapacity = value; } }
    public int ParkedVehicles
    {
        get { return parkedVehicles; }
        private set
        {
            parkedVehicles = value;
            FreeParkingSpots = maxCapacity - parkedVehicles;
        }
    }
    public int FreeParkingSpots { get { return freeParkingSpots; } private set { freeParkingSpots = value; } }
    public string Name { get { return name; } private set { name = value; } }

    //Constructors
    public Garage(string name, int maxCapacity)
    {
        Name = name;
        MaxCapacity = maxCapacity;
        ParkedVehicles = 0;
        FreeParkingSpots = maxCapacity - parkedVehicles;
        vehicles = new Vehicle[maxCapacity];
    }
    public Garage(string name, int maxCapacity, params Vehicle[] vehicles)
    {
        Name = name;
        MaxCapacity = maxCapacity;
        ParkedVehicles = 0;
        FreeParkingSpots = maxCapacity - parkedVehicles;
        this.vehicles = new Vehicle[maxCapacity];
        for (int i = 0; i < vehicles.Length; i++)
        {
            this.vehicles[parkedVehicles++] = vehicles[i];
        }
    }

    //Public Methods
    public void AddVehicle(T vehicle)
    {
        if (parkedVehicles >= maxCapacity)
            throw new ArgumentOutOfRangeException($"The garage is full: {parkedVehicles} vs {maxCapacity}");
        vehicles[ParkedVehicles++] = vehicle;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < ParkedVehicles; i++)
        {
            yield return (T)vehicles[i];
        }
    }

    public T GetVehicleFromRegistration(string registrationNumber)
    {
        throw new NotImplementedException();
    }

    public Vehicle[] GetListVehicles()
    {
        Vehicle[] newVehicles = new Vehicle[maxCapacity];
        for (int i = 0; i < parkedVehicles; i++)
        {
            newVehicles[i] = vehicles[i];
        }
        return newVehicles;
    }

    public Vehicle[] GetListSpecificVehicles()
    {
        throw new NotImplementedException();
    }

    public Vehicle[] GetListAttributeVehicles()
    {
        throw new NotImplementedException();
    }

    public void RemoveVehicle(T vehicle)
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }


    //Private Methods


    //Destructors


}

