namespace Excersize_5_Lexicon.Garages;

internal interface IGarageMethodsOut<out T>
{
    public T GetVehicleFromRegistration(string registrationNumber);
}

