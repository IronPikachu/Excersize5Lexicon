using System;

namespace Excersize_5_Lexicon.Vehicles;

public class Car : Vehicle
{
    //Fields
    private string brand = "";

    //Propertys
    public string Brand
    {
        get { return brand; }
        private set
        {
            brand = value ?? throw new ArgumentNullException("Creator cannot be null");
        }
    }

    //Constructors
    public Car(string registryNumber, string ownerName, string color, int amountOfWheels, int price, string brand) : base(registryNumber, ownerName, color, amountOfWheels, price)
    {
        Brand = brand;
    }


    //Public Methods
    public override string ToString()
    {
        return base.ToString() + $" It was made by {Brand}";
    }

    public override bool Equals(IVehicle? other)
    {
        if (other == null)
            return false;
        return base.Equals(other) && Brand == ((Car)other).Brand;
    }

    //Private Methods


    //Destructors


}
