using Excersize_5_Lexicon.Vehicles;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Excersize_5_Lexicon.Garages;

[JsonObject]
public class Garage<T> : IGarage<T> where T : IVehicle
{
    //Fields
    [JsonProperty]
    private string name = "";
    [JsonProperty]
    private int maxCapacity;
    private int parkedVehicles;
    private int freeParkingSpots;
    [JsonProperty]
    private T?[] vehicles;

    //Propertys
    [JsonIgnore]
    public int MaxCapacity { get { return maxCapacity; } private set { maxCapacity = value; } }
    [JsonIgnore]
    public int ParkedVehicles
    {
        get { return parkedVehicles; }
        private set
        {
            parkedVehicles = value;
            FreeParkingSpots = MaxCapacity - parkedVehicles;
        }
    }
    [JsonIgnore]
    public int FreeParkingSpots { get { return freeParkingSpots; } private set { freeParkingSpots = value; } }
    [JsonIgnore]
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

    [JsonConstructor]
    public Garage(string name, int maxCapacity, params T[] vehicles)
    {
        Name = name;
        MaxCapacity = maxCapacity;
        ParkedVehicles = 0;
        this.vehicles = new T[maxCapacity];
        for (int i = 0; i < vehicles.Length; i++)
        {
            if (vehicles[i] == null)
                break;
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
            if(vehicles[i]!.Equals(vehicle))
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
            if (vehicles[i]!.Equals(vehicle))
            {
                vehicles[i] = default;
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
                vehicles[i + 1] = default;
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

