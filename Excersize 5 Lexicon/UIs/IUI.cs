using Excersize_5_Lexicon.Vehicles;

namespace Excersize_5_Lexicon.UIs
{
    public interface IUI
    {
        string UserName { get; }

        char AddGarageMenu(char[] validChars);
        char TypeOfVehicleMenu(char[] validChars, List<string> availableVehicles);
        string GetGarageNameFromUser(string message);
        int GetCapacityFromUser(string message, int min = 0);
        Vehicle GetVehicleFromUser<T>() where T : Vehicle;
        char AddVehicleMenu(char[] validChars, List<string> availableVehicles);
        void Farewell();
        void Greetings();
        char MainMenu(int nrOfGarages, char[] validChars);
        void PrintErrorMessage(string message);
        void PrintMessage(string message);
    }
}