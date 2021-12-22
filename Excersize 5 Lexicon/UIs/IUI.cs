using Excersize_5_Lexicon.Vehicles;
using System.Collections.Generic;

namespace Excersize_5_Lexicon.UIs
{
    public interface IUI
    {
        string UserName { get; }

        char AddGarageMenu(char[] validChars);
        char TypeOfVehicleMenu(char[] validChars, List<string> availableVehicles);
        string GetGarageNameFromUser(string message);
        int GetCapacityFromUser(string message, int min = 0);
        IVehicle GetVehicleFromUser<T>() where T : IVehicle;
        char AddVehicleMenu(char[] validChars, List<string> availableVehicles);
        void Farewell();
        void Greetings();
        char MainMenu(int nrOfGarages, char[] validChars);
        void PrintErrorMessage(string message);
        void PrintMessage(string message);
        int PromptInt(int min = int.MinValue);
    }
}