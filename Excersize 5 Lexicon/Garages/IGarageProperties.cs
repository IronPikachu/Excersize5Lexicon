namespace Excersize_5_Lexicon.Garages;

interface IGaragePropertys
{
    //Propertys
    public int MaxCapacity { get; }
    public int ParkedVehicles { get; }
    public int FreeParkingSpots { get; }
    public string Name { get; }
}

