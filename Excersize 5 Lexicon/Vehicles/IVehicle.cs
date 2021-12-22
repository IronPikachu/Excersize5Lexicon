﻿namespace Excersize_5_Lexicon.Vehicles
{
    public interface IVehicle
    {
        int AmountOfWheels { get; }
        string Color { get; }
        string OwnerName { get; }
        int Price { get; }
        string RegistryNumber { get; }

        string ToString();
    }
}