using System;

namespace Excersize_5_Lexicon.Vehicles;

public class Unicycle : Vehicle
{
    //Fields
    private double weightLimit;

    //Propertys
    public double WeightLimit
    {
        get { return weightLimit; }
        private set
        {
            if (value < 0)
                throw new ArgumentException("WeightLimit cannot be less than zero");
            weightLimit = value;
        }
    }

    //Constructors
    public Unicycle(string registryNumber, string ownerName, string color, int amountOfWheels, int price, double weightLimit) : base(registryNumber, ownerName, color, amountOfWheels, price)
    {
        WeightLimit = weightLimit;
    }

    //Public Methods
    public override string ToString()
    {
        return base.ToString() + $" You must weight less than {WeightLimit} kg unless you want to break it...";
    }

    public override bool Equals(IVehicle? other)
    {
        if (other == null)
            return false;
        return base.Equals(other) && WeightLimit == ((Unicycle)other).WeightLimit;
    }

    //Private Methods


    //Destructors
}
