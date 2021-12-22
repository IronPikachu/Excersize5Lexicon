using Excersize_5_Lexicon.Vehicles;
using System.Collections;

namespace Excersize_5_Lexicon.Garages;

public class Garage<T> : IGarage<T> where T : IVehicle
{
    //Fields
    private string name = "";
    private int maxCapacity;
    private int parkedVehicles;
    private int freeParkingSpots;
    private T?[] vehicles;

    //Propertys
    public int MaxCapacity { get { return maxCapacity; } private set { maxCapacity = value; } }
    public int ParkedVehicles
    {
        get { return parkedVehicles; }
        private set
        {
            parkedVehicles = value;
            FreeParkingSpots = MaxCapacity - parkedVehicles;
        }
    }
    public int FreeParkingSpots { get { return freeParkingSpots; } private set { freeParkingSpots = value; } }
    public string Name
    {
        get { return name; }
        private set
        {
            name = value ?? throw new ArgumentNullException("Name cannot be null");
        }
    }

    //Constructors
    public Garage(string name, int maxCapacity)
    {
        Name = name;
        MaxCapacity = maxCapacity;
        ParkedVehicles = 0;
        vehicles = new T[maxCapacity];
    }

    public Garage(string name, int maxCapacity, params T[] vehicles)
    {
        Name = name;
        MaxCapacity = maxCapacity;
        ParkedVehicles = 0;
        this.vehicles = new T[maxCapacity];
        for (int i = 0; i < vehicles.Length; i++)
        {
            this.vehicles[ParkedVehicles++] = vehicles[i];
        }
    }

    //Public Methods
    //AddVehicle returns true on success, false if container is full
    public bool AddVehicle(T vehicle)
    {
        if (!(parkedVehicles < maxCapacity))
            return false;
        vehicles[ParkedVehicles++] = vehicle;
        return true;
    }
    //VehicleExists returns true if vehicle exists, false if it doesn't
    public bool VehicleExists(T vehicle)
    {
        for (int i = 0; i < ParkedVehicles; i++)
        {
            if(vehicles[i] == vehicle)
                return true;
        }
        return false;
    }
    //RemoveVehicle returns true on succesfull removal, false if vehicle does not exist
    public bool RemoveVehicle(T vehicle)
    {
        bool success = false;
        for (int i = 0; i < ParkedVehicles; i++)
        {
            if (vehicles[i] == vehicle)
            {
                vehicles[i] = null;
                success = true;
                break;
            }
        }
        if(!success)
            return false;
        
        ParkedVehicles--;

        for (int i = 0; i < ParkedVehicles; i++)
        {
            if(vehicles[i] == null && vehicles[i + 1] != null)
            {
                vehicles[i] = vehicles[i + 1];
                vehicles[i + 1] = null;
            }
        }

        return true;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < ParkedVehicles; i++)
        {
            yield return vehicles[i]!;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }


    //Private Methods


    //Destructors


}

