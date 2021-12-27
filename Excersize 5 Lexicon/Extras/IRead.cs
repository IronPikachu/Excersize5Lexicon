using Excersize_5_Lexicon.Garages;
using Excersize_5_Lexicon.Vehicles;

namespace Excersize_5_Lexicon.Extras;

internal interface IRead<T> where T : IVehicle
{
    IGarage<T> Read(string fileName);
}
