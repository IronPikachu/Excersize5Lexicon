using Excersize_5_Lexicon.Garages;
using Excersize_5_Lexicon.Handlers;
using Excersize_5_Lexicon.UIs;
using Excersize_5_Lexicon.Vehicles;

namespace Excersize_5_Lexicon.Manager;

public class GarageManager : IGarageMethodsIn<Vehicle>
{
    //Fields
    private IUI userInterface = new UI();
    private IHandler handler = new Handler();
    private List<IGarage<Vehicle>> garages;

    //Propertys


    //Constructors


    //Public Methods
    public bool AddVehicle(Vehicle vehicle)
    {
        throw new NotImplementedException();
    }

    public bool RemoveVehicle(Vehicle vehicle)
    {
        throw new NotImplementedException();
    }

    public bool VehicleExists(Vehicle vehicle)
    {
        throw new NotImplementedException();
    }



    //Private Methods


    //Destructors
}
