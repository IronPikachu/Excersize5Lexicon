using Excersize_5_Lexicon.Extras;
using Excersize_5_Lexicon.Garages;
using Excersize_5_Lexicon.Vehicles;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Excersize_5_Lexicon.Handlers;

public class Handler<T> : IHandler<T>, ICRUD<T> where T : IVehicle
{
    //Fields
    private IGarage<T> garage;
    public static readonly string path = @"SavedObjects\";

    //Propertys
    public string GarageName { get { return garage.Name; } }
    public int MaxCapacity { get { return garage.MaxCapacity; } }

    //Constructors
    public Handler(string fileName)
    {
        garage = Read(fileName) ?? throw new NullReferenceException($"{fileName} returned a null value");
    }
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
        Update();
    }
   
    //Public Methods
    public bool AddVehicle(IVehicle vehicle)
    {
        if (!garage.AddVehicle((T)vehicle))
            return false;
        Update();
        return true;
    }

    public bool RemoveVehicle(IVehicle vehicle)
    {
        if (!garage.RemoveVehicle((T)vehicle))
            return false;
        Update();
        return true;
    }

    public bool VehicleExists(IVehicle vehicle)
    {
        return garage.VehicleExists((T)vehicle);
    }

    public IEnumerable<T> SearchVehicles(Func<IVehicle, bool> predicate)
    {
        return this.Where(p => predicate(p));
    }

    public IEnumerator<T> GetEnumerator()
    {
        return garage.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public Type GetGenericType()
    {
        return typeof(T);
    }

    public void Create()
    {
        string fileName = $"{path}{GarageName}_{GetGenericType().Name}.json";

        string jsonString = JsonConvert.SerializeObject((Garage<T>)garage);

        //Save jsonString to fileName

        File.WriteAllText(fileName, jsonString);
    }

    public IGarage<T> Read(string fileName)
    {
        if (File.Exists(fileName))
        {
            string readText = File.ReadAllText(fileName);

            IGarage<T> readGarage = JsonConvert.DeserializeObject<Garage<T>>(readText) ?? throw new ArgumentNullException($"Something was null");
            return readGarage; //Cannot cast atm!
        }
        throw new FileNotFoundException($"Could not find {fileName}");
    }

    public void Update()
    {
        string fileName = $"{path}{GarageName}_{GetGenericType().Name}.json";

        //Update existing file

        if (!File.Exists(path))
        {
            Create();
            return;
        }
        string jsonString = JsonConvert.SerializeObject((Garage<T>)garage);
        File.WriteAllText(fileName, jsonString);
    }

    public void Delete()
    {
        string fileName = $"{path}{GarageName}_{GetGenericType().Name}.json";

        //Delete file

        File.Delete(path);
    }

    //Private Methods


    //Destructors

}