using Excersize_5_Lexicon.Garages;
using Excersize_5_Lexicon.Vehicles;

namespace Excersize_5_Lexicon.Handlers;

public class Handler<T> : IHandler<T> where T : IVehicle
{
    //Fields
    private Garage<T> garage;

    //Propertys
    public string GarageName { get { return garage.Name; } }

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
    public bool AddVehicle(T vehicle)
    {
        return garage.AddVehicle(vehicle);
    }

    public bool RemoveVehicle(T vehicle)
    {
        return garage.RemoveVehicle(vehicle);
    }

    public bool VehicleExists(T vehicle)
    {
        return garage.VehicleExists(vehicle);
    }

    //Private Methods


    //Destructors
}