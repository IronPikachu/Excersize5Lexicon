using Excersize_5_Lexicon.Garages;
using Excersize_5_Lexicon.Vehicles;

namespace Excersize_5_Lexicon.Handlers;

public interface IHandler<T> : IGarageMethodsIn<T> where T : IVehicle
{
    //Propertys
    string GarageName { get; }

    //Public Methods


    //Private Methods


}
