namespace Excersize_5_Lexicon.Vehicles;

public class Bus : Vehicle
{
    //Fields
    private int seats;


    //Propertys
    public int Seats
    {
        get { return seats; }
        private set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("Seats cannot be less than zero");
            seats = value;
        }
    }


    //Constructors
    public Bus(string registryNumber, string ownerName, string color, int amountOfWheels, int price, int seats) : base(registryNumber, ownerName, color, amountOfWheels, price)
    {
        Seats = seats;
    }


    //Public Methods
    public override string ToString()
    {
        return base.ToString() + $" There are {Seats} seats.";
    }

    //Private Methods


    //Destructors


}
