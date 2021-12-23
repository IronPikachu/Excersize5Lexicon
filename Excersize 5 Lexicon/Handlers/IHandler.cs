using Excersize_5_Lexicon.Garages;
using Excersize_5_Lexicon.Vehicles;
using System;
using System.Collections.Generic;

namespace Excersize_5_Lexicon.Handlers;

public interface IHandler<out T> : IGarageMethodsIn<IVehicle>, IEnumerable<T> where T : IVehicle
{
    //Propertys
    string GarageName { get; }
    int MaxCapacity { get; }

    //Public Methods
    Type GetGenericType();


    //Private Methods


}

/*
    interface ITest<out A, in B> //Valid
    {
        A GetSomething();
        void SetSomething(B arg);
        R GetSomethingSpecific(B arg);
    }
 
 */
