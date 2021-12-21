namespace Excersize_5_Lexicon.Vehicles;

public class Motorcycle : Vehicle
{
    //Fields
    private int weight;

    //Propertys
    public int Weight
    {
        get { return weight; }
        private set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("Weight cannot be less than zero");
            weight = value;
        }
    }

    //Constructors
    public Motorcycle(string registryNumber, string ownerName, string color, int amountOfWheels, int price, int weight) : base(registryNumber, ownerName, color, amountOfWheels, price)
    {
        Weight = weight;
    }

    //Public Methods
    public override string ToString()
    {
        return base.ToString() + $" It weights {Weight} kg!";
    }

    //Private Methods


    //Destructors
}
