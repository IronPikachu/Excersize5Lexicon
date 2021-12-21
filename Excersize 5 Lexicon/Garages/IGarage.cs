using Excersize_5_Lexicon.Vehicles;

namespace Excersize_5_Lexicon.Garages;

internal interface IGarage<T> : IGarageMethodsIn<T>, IGarageMethodsOut<T>, IEnumerable<T> where T : Vehicle
{
    //Propertys
    public int MaxCapacity { get; }
    public int ParkedVehicles { get; }
    public int FreeParkingSpots { get; }
    public string Name { get; }

    //Public methods
    public Vehicle[] GetListVehicles();
    public Vehicle[] GetListSpecificVehicles();
    public Vehicle[] GetListAttributeVehicles();
}
