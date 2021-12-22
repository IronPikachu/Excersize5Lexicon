using Excersize_5_Lexicon.Vehicles;

namespace Excersize_5_Lexicon.Garages;

public interface IGarageMethodsIn<in T>
{
    //Public Methods
    public bool AddVehicle(T vehicle);
    public bool RemoveVehicle(T vehicle);
    public bool VehicleExists(T vehicle);
}
