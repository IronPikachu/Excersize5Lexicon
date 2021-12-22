using Excersize_5_Lexicon.Extras;
using Excersize_5_Lexicon.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Excersize_5_Lexicon.UIs;

public class UI : IUI
{

    //Fields

    //Propertys
    public string UserName { get; }


    //Constructors
    public UI(string name)
    {
        UserName = name ?? "Anonymous User";
    }


    //Public Methods
    public void Greetings()
    {
        Console.Clear();
        string greeting = "";
        greeting += $"Hello {UserName} and welcome to the garage manager!";
        Console.WriteLine(greeting);
    }

    public void Farewell()
    {
        Console.Clear();
        string farewell = "";
        farewell += $"Goodbye {UserName}, I hope to see you soon!\nHave a good one!\n";

        Console.WriteLine(farewell);
    }

    public char MainMenu(int nrOfGarages, char[] validChars)
    {
        Console.Clear();
        string menu = "";
        int option = 1;
        menu += "Press keys to choose an option:\n";
        //Add garage
        menu += $"{option++}. Add Garage\n"; //-> Set capacity, add vehicles from start, or read from json
        //Add and remove
        menu += $"{option++}. Add Vehicle\n"; //-> Which garage
        menu += $"{option++}. Remove Vehicle\n"; //-> Which garage
        //Find vehicle
        menu += $"{option++}. Find Vehicle\n"; //-> Specific or all garages, search for what?
        //List Vehicle
        menu += $"{option++}. List Vehicles\n";//-> Specific or all garages, type of vehicle

        //Terminate
        menu += "0. Exit.\n\n";
        menu += $"There are currently {nrOfGarages} garages active.\n\n";

        Console.WriteLine(menu);
        return PromptKey(validChars);
    }

    public char AddGarageMenu(char[] validChars)
    {
        Console.Clear();
        int option = 1;

        string menu = "";
        //Set only capacity
        menu += $"{option++}. Start a new garage with only a specific amount of spaces.\n";
        //Add vehicles from start and add capacity
        menu += $"{option++}. Add vehicles from the start.\n";
        //Read from json
        menu += $"{option++}. Read garage from json.\n";

        //Cancel
        menu += "0. Cancel and return to main menu.\n\n";

        Console.WriteLine(menu);
        return PromptKey(validChars);
    }

    public char TypeOfVehicleMenu(char[] validChars, List<string> availableVehicles)
    {
        Console.Clear();
        int option = 1;

        string menu = "";
        for (int i = 0; i < availableVehicles.Count; i++)
        {
            menu += $"{option++}: {availableVehicles[i]}.\n";
        }

        //Everything
        menu += $"{option++}: Yes.\n";

        //Cancel
        menu += "0. Cancel and return to main menu.\n\n";

        Console.WriteLine(menu);
        return PromptKey(validChars);
    }

    public string GetGarageNameFromUser(string message)
    {
        PrintMessage(message);
        return PromptString();
    }

    public int GetCapacityFromUser(string message, int min = 0)
    {
        Console.WriteLine(message);
        int capacity;
        while (true)
        {
            capacity = PromptInt();
            if (capacity < min)
                PrintErrorMessage($"Enter a value higher than {min}!");
            else
                return capacity;
        }
    }

    public IVehicle GetVehicleFromUser<T>() where T : IVehicle
    {
        Console.Clear();
        PrintMessage($"Please enter the registry number of the {typeof(T)}.");
        string regNum = PromptString();
        PrintMessage($"Please enter the name of the ownder of the {typeof(T)}.");
        string owner = PromptString();
        PrintMessage($"What color is the {typeof(T)}?");
        string color = PromptString();
        PrintMessage($"How many wheels does the {typeof(T)} have?");
        int wheels = PromptInt(1);
        PrintMessage($"What is the price of the {typeof(T)}?");
        int price = PromptInt(0);
        if (typeof(T) == typeof(Airplane))
        {
            PrintMessage($"What is the wingspan?");
            double wing = PromptDouble(0d);
            Airplane airplane = new Airplane(regNum, owner, color, wheels, price, wing);
            return airplane;
        }
        else if (typeof(T) == typeof(Boat))
        {
            PrintMessage($"What is your {typeof(T)}s name?");
            string boatName = PromptString();
            Boat boat = new Boat(regNum, owner, color, wheels, price, boatName);
            return boat;
        }
        else if (typeof(T) == typeof(Bus))
        {
            PrintMessage($"How many seats does the {typeof(T)} have?");
            int seats = PromptInt(0);
            Bus bus = new Bus(regNum, owner, color, wheels, price, seats);
            return bus;
        }
        else if (typeof(T) == typeof(Car))
        {
            PrintMessage($"What brand is your {typeof(T)}?");
            string brand = PromptString();
            Car car = new Car(regNum, owner, color, wheels, price, brand);
            return car;
        }
        else if (typeof(T) == typeof(Motorcycle))
        {
            PrintMessage($"How heavy is your {typeof(T)}?");
            int weight = PromptInt(0);
            Motorcycle mc = new Motorcycle(regNum, owner, color, wheels, price, weight);
            return mc;
        }
        else if (typeof(T) == typeof(Unicycle))
        {
            PrintMessage($"How much weight can it hold?");
            double weight = PromptDouble(0);
            Unicycle unicycle = new Unicycle(regNum, owner, color, wheels, price, weight);
            return unicycle;
        }
        else if (typeof(T) == typeof(Vehicle))
        {
            throw new ArgumentException($"Can't create a generic {typeof(T)}!");
        }
        else
        {
            throw new ArgumentException($"Couldn't decide type of {typeof(T)}, and it went terribly wrong.");
        }
    }

    public char AddVehicleMenu(char[] validChars, List<string> availableVehicles)
    {
        Console.Clear();
        int option = 1;

        string menu = "";
        for (int i = 0; i < availableVehicles.Count; i++)
        {
            menu += $"{option++}: {availableVehicles[i]}.\n";
        }

        //Cancel
        menu += "0. Cancel and return to main menu.\n\n";

        Console.WriteLine(menu);
        return PromptKey(validChars);
    }



    public void PrintErrorMessage(string message)
    {
        var color = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{UserName}, you fucked up. Here's what I got: {message}");
        Console.ForegroundColor = color;
    }

    public void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }
    public int PromptInt(int min = int.MinValue)
    {
        string unformattedResult = Console.ReadLine()!;
        int result;
        while (true)
        {
            if (int.TryParse(unformattedResult, out result))
            {
                if (result < min)
                    PrintErrorMessage($"Integer should be greater than {min}.");
                else
                    return result;
            }
            else
                PrintErrorMessage("Enter an integer!");
            unformattedResult = Console.ReadLine()!;
        }
    }
    //Private Methods
    private char PromptKey(char[] validChars)
    {
        char keyPressed = Console.ReadKey().KeyChar;
        keyPressed = char.ToLower(keyPressed);
        validChars.ToLower();
        Console.WriteLine();
        while (!validChars.Contains(keyPressed))
        {
            PrintErrorMessage("Invalid key pressed! Please look at the options...");
            keyPressed = char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine();
        }

        return keyPressed;
    }
    private string PromptString()
    {
        string result = Console.ReadLine()!;
        while (string.IsNullOrEmpty(result))
        {
            PrintErrorMessage("Enter a string!");
            result = Console.ReadLine()!;
        }

        return result;
    }
    //I'm not proud, should probably refactor it...
    private double PromptDouble(double min = double.MinValue)
    {
        string unformattedResult = Console.ReadLine()!;
        double result;
        while (true)
        {
            if (double.TryParse(unformattedResult, out result))
            {
                if (result < min)
                    PrintErrorMessage($"Double should be greater than {min}.");
                else
                    return result;
            }
            else
                PrintErrorMessage("Enter an integer!");
            unformattedResult = Console.ReadLine()!;
        }
    }

    //Destructors
}
