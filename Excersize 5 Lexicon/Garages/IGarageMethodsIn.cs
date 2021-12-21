namespace Excersize_5_Lexicon.Garages;

interface IGarageMethodsIn<in T> 
{
    //Public Methods
    public bool AddVehicle(T vehicle);
    public bool RemoveVehicle(T vehicle);
    public bool VehicleExists(T vehicle);
}
