namespace Excersize_5_Lexicon.Garages;

internal interface IGarageMethodsOut<out T>
{
    //Public methods
    public T GetVehicleFromRegistration(string registrationNumber);
}

