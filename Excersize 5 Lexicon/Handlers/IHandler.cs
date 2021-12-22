using Excersize_5_Lexicon.Garages;
using Excersize_5_Lexicon.Vehicles;
using System;

namespace Excersize_5_Lexicon.Handlers;

public interface IHandler<T> : IGarageMethodsIn<T> where T : IVehicle
{
    //Propertys
    string GarageName { get; }
    int MaxCapacity { get; }
    Type GetGenericType();

    //Public Methods


    //Private Methods


}
