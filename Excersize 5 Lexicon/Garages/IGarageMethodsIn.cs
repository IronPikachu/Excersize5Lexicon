namespace Excersize_5_Lexicon.Garages;

interface IGarageMethodsIn<in T> 
{
    //Public Methods
    public void AddVehicle(T vehicle);
    public void RemoveVehicle(T vehicle);
}
