using Excersize_5_Lexicon.Vehicles;
using System.Collections;

namespace Excersize_5_Lexicon.Garages;

class Garage<T> : IGarage<T> where T : Vehicle
{
    //Fields
    private int maxCapacity;
    private int parkedVehicles;
    private int freeParkingSpots;
    private string name;
    private Vehicle[] vehicles;

    //Propertys
    public int MaxCapacity { get { return maxCapacity; } private set { maxCapacity = value; } }
    public int ParkedVehicles { get { return parkedVehicles; } private set { parkedVehicles = value; } }
    public int FreeParkingSpots { get { return freeParkingSpots; } private set { freeParkingSpots = value; } }
    public string Name { get { return name; } private set { name = value; } }

    //Constructors
    public Garage(string name, int maxCapacity)
    {
        this.name = name;
        this.maxCapacity = maxCapacity;
        this.parkedVehicles = 0;
        this.freeParkingSpots = maxCapacity - parkedVehicles;
        vehicles = new Vehicle[maxCapacity];
    }
    public Garage(string name, int maxCapacity, params Vehicle[] vehicles)
    {
        this.name = name;
        this.maxCapacity = maxCapacity;
        this.parkedVehicles = 0;
        this.freeParkingSpots = maxCapacity - parkedVehicles;
        this.vehicles = new Vehicle[maxCapacity];
        for (int i = 0; i < vehicles.Length; i++)
        {
            this.vehicles[parkedVehicles++] = vehicles[i];
        }
    }

    //Public Methods
    public void AddVehicle(T vehicle)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public T GetVehicleFromRegistration(string registrationNumber)
    {
        throw new NotImplementedException();
    }

    public void ListAttributeVehicles()
    {
        throw new NotImplementedException();
    }

    public void ListSpecificVehicles(T type)
    {
        throw new NotImplementedException();
    }

    public void ListVehicles()
    {
        throw new NotImplementedException();
    }

    public void RemoveVehicle(T vehicle)
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }


    //Private Methods


    //Destructors


}

