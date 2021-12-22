using Excersize_5_Lexicon.Vehicles;
using System.Collections.Generic;

namespace Excersize_5_Lexicon.Garages;

public interface IGarage<T>: IGarageMethodsIn<T>, IEnumerable<T> where T : IVehicle
{
    //Propertys
    public int MaxCapacity { get; }
    public int ParkedVehicles { get; }
    public int FreeParkingSpots { get; }
    public string Name { get; }

}
