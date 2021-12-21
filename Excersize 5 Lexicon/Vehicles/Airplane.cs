namespace Excersize_5_Lexicon.Vehicles;

public class Airplane : Vehicle
{
    //Fields
    private double wingSpan;



    //Propertys
    public double WingSpan
    {
        get { return wingSpan; }
        private set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("WingSpan cannot be less than zero");
            wingSpan = value;
        }
    }

    //Constructors
    public Airplane(string registryNumber, string ownerName, string color, int amountOfWheels, int price, double wingSpan) : base(registryNumber, ownerName, color, amountOfWheels, price)
    {
        WingSpan = wingSpan;
    }

    //Public Methods
    public override string ToString()
    {
        return base.ToString() + $" It has an amazing wingspan of {WingSpan} meters!";
    }

    //Private Methods


    //Destructors


}
