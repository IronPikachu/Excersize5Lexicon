using System;

namespace Excersize_5_Lexicon.Vehicles;

public class Boat : Vehicle
{
    //Fields
    private string boatName = "";

    //Propertys
    public string BoatName
    {
        get { return boatName; }
        private set
        {
            boatName = value ?? throw new ArgumentNullException("BoatName cannot be null");
        }
    }

    //Constructors
    public Boat(string registryNumber, string ownerName, string color, int amountOfWheels, int price, string boatName) : base(registryNumber, ownerName, color, amountOfWheels, price)
    {
        BoatName = boatName;
    }


    //Public Methods
    public override string ToString()
    {
        return base.ToString() + $" This boats name is {BoatName}.";
    }

    public override bool Equals(IVehicle? other)
    {
        if (other == null)
            return false;
        return base.Equals(other) && BoatName == ((Boat)other).BoatName;
    }

    //Private Methods


    //Destructors
}
