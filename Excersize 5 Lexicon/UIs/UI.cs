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
        ClearWindow();
        string greeting = "";
        greeting += $"Hello {UserName} and welcome to the garage manager!";
        Console.WriteLine(greeting);
    }

    public void Farewell()
    {
        ClearWindow();
        string farewell = "";
        farewell += $"Goodbye {UserName}, I hope to see you soon!\nHave a good one!\n";

        Console.WriteLine(farewell);
    }

    public char MainMenu(int nrOfGarages, char[] validChars)
    {
        ClearWindow();
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
        string singular = "garage";
        if (nrOfGarages != 1)
            singular += "s";
        menu += $"There are currently {nrOfGarages} {singular} active.\n\n";

        Console.WriteLine(menu);
        return PromptKey(validChars);
    }

    public char AddGarageMenu(char[] validChars)
    {
        ClearWindow();
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
        ClearWindow();
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
        ClearWindow();
        PrintMessage(message);
        return PromptString();
    }

    public int GetCapacityFromUser(string message, int min = 0)
    {
        ClearWindow();
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

    public IVehicle GetVehicleFromUser(Type type)
    {
        ClearWindow();
        string name = type.Name;
        PrintMessage($"Please enter the registry number of the {name}.");
        string regNum = PromptString();
        PrintMessage($"Please enter the name of the owner of the {name}.");
        string owner = PromptString();
        PrintMessage($"What color is the {name}?");
        string color = PromptString();
        PrintMessage($"How many wheels does the {name} have?");
        int wheels = PromptInt(0);
        PrintMessage($"What is the price of the {name}?");
        int price = PromptInt(0);
        /*        switch (type.Name)
                {
                    case nameof(Airplane):
                        break;
                }*/
        if (type == typeof(Airplane))
        {
            PrintMessage($"What is the wingspan?");
            double wing = PromptDouble(0d);
            Airplane airplane = new Airplane(regNum, owner, color, wheels, price, wing);
            return airplane;
        }
        else if (type == typeof(Boat))
        {
            PrintMessage($"What is your {name}s name?");
            string boatName = PromptString();
            Boat boat = new Boat(regNum, owner, color, wheels, price, boatName);
            return boat;
        }
        else if (type == typeof(Bus))
        {
            PrintMessage($"How many seats does the {name} have?");
            int seats = PromptInt(0);
            Bus bus = new Bus(regNum, owner, color, wheels, price, seats);
            return bus;
        }
        else if (type == typeof(Car))
        {
            PrintMessage($"What brand is your {name}?");
            string brand = PromptString();
            Car car = new Car(regNum, owner, color, wheels, price, brand);
            return car;
        }
        else if (type == typeof(Motorcycle))
        {
            PrintMessage($"How heavy is your {name}?");
            int weight = PromptInt(0);
            Motorcycle mc = new Motorcycle(regNum, owner, color, wheels, price, weight);
            return mc;
        }
        else if (type == typeof(Unicycle))
        {
            PrintMessage($"How much weight can it hold?");
            double weight = PromptDouble(0);
            Unicycle unicycle = new Unicycle(regNum, owner, color, wheels, price, weight);
            return unicycle;
        }
        else if (type == typeof(Vehicle))
        {
            throw new ArgumentException($"Can't create a generic {name}!");
        }
        else
        {
            throw new ArgumentException($"Couldn't decide type of {name}, and it went terribly wrong.");
        }
    }

    public int AddVehicleMenu(List<string> availableGarages)
    {
        ClearWindow();
        Console.WriteLine($"In which garage do you want to add a vehicle?\n");

        string menu = "";

        for (int i = 0; i < availableGarages.Count; i++)
            menu += $"{i + 1}\t-\t{availableGarages[i]}.\n";
        menu += $"\n{0}\t-\tExit.";

        Console.WriteLine(menu);
        int min = 0, max = availableGarages.Count + 1;

        int who = PromptInt(min: min, max: max);

        return who;
    }

    public int RemoveVehicleMenu(List<string> availableGarages)
    {
        ClearWindow();
        Console.WriteLine($"In which garage do you want to add a vehicle?\n");

        string menu = "";

        for (int i = 0; i < availableGarages.Count; i++)
            menu += $"{i + 1}\t-\t{availableGarages[i]}.\n";
        menu += $"\n{0}\t-\tExit.";

        Console.WriteLine(menu);
        int min = 0, max = availableGarages.Count + 1;

        int who = PromptInt(min: min, max: max);

        return who;
    }

    public Func<IVehicle, bool> FindPredicateFromUser()
    {
        PrintMessage($"Which attribute would you like to search for?\n");
        // Strings should be == or contains: Numbers should be ==, <, >, <= or >=
        // Begin with regular vehicle
        string menu = "";
        int options = 1;

        menu += $"{options++}. Registry Number.\n";
        menu += $"{options++}. Owner Name.\n";
        menu += $"{options++}. Color.\n";
        menu += $"{options++}. Wheel Amount.\n";
        menu += $"{options++}. Price.\n";

        menu += $"\n{0}. Exit.\n";

        PrintMessage(menu);
        char[] valid = new char[options + 1];
        for (int i = 0; i <= options; i++)
            valid[i] = $"{i}"[0];
        char option = PromptKey(valid);
        char option2;
        string stringVal;
        int intVal;
        string menuInt;
        string[] operators;
                ClearWindow();
        switch (option)
        {
            case '0':
                return p => true;
            case '1':   //Registry number, string, contains string or complete string?
                PrintMessage($"Which method?\n1. Full string.\n2. Contains.");
                option2 = PromptKey(new char[] { '1', '2' });
                stringVal = PromptString();
                if (option2 == '1')
                    return p => p.RegistryNumber == stringVal.ToUpper();
                else if (option2 == '2')
                    return p => p.RegistryNumber.Contains(stringVal.ToUpper());
                throw new ArgumentException($"Options whack, develop better");
            case '2':   //Owner name, string
                PrintMessage($"Which method?\n1. Full string.\n2. Contains.");
                option2 = PromptKey(new char[] { '1', '2' });
                stringVal = PromptString();
                if (option2 == '1')
                    return p => p.OwnerName == stringVal;
                else if (option2 == '2')
                    return p => p.OwnerName.Contains(stringVal);
                throw new ArgumentException($"Options whack, develop better");
            case '3':   //Color, string
                PrintMessage($"Please enter the color: ");
                stringVal = PromptString();
                return p => p.Color == stringVal;
            case '4':   //Wheel amount, int
                options = 1;
                operators = new string[] { "==", "<", ">", "<=", ">=", "!=" };
                menuInt = $"Choose operator:\n";
                menuInt += $"{options++}. '{operators[0]}'\n";
                menuInt += $"{options++}. '{operators[1]}'\n";
                menuInt += $"{options++}. '{operators[2]}'\n";
                menuInt += $"{options++}. '{operators[3]}'\n";
                menuInt += $"{options++}. '{operators[4]}'\n";
                menuInt += $"{options++}. '{operators[5]}'\n\n";
                PrintMessage(menuInt);

                option2 = PromptKey(new char[] { '1', '2', '3', '4', '5', '6' });

                ClearWindow();
                PrintMessage("Enter the value: ");
                intVal = PromptInt(min: 0);

                switch (option2)
                {
                    case '1':
                        return p => p.AmountOfWheels == intVal;
                    case '2':
                        return p => p.AmountOfWheels < intVal;
                    case '3':
                        return p => p.AmountOfWheels > intVal;
                    case '4':
                        return p => p.AmountOfWheels <= intVal;
                    case '5':
                        return p => p.AmountOfWheels >= intVal;
                    case '6':
                        return p => p.AmountOfWheels != intVal;
                    default:
                        throw new ArgumentException("Terrible terrible things...");
                }
            case '5':   //Price, int
                options = 1;
                operators = new string[] { "==", "<", ">", "<=", ">=", "!=" };
                menuInt = $"Choose operator:\n";
                menuInt += $"{options++}. '{operators[0]}'\n";
                menuInt += $"{options++}. '{operators[1]}'\n";
                menuInt += $"{options++}. '{operators[2]}'\n";
                menuInt += $"{options++}. '{operators[3]}'\n";
                menuInt += $"{options++}. '{operators[4]}'\n";
                menuInt += $"{options++}. '{operators[5]}'\n\n";
                PrintMessage(menuInt);

                option2 = PromptKey(new char[] { '1', '2', '3', '4', '5', '6' });

                ClearWindow();
                PrintMessage("Enter the value: ");
                intVal = PromptInt(min: 0);

                switch (option2)
                {
                    case '1':
                        return p => p.Price == intVal;
                    case '2':
                        return p => p.Price < intVal;
                    case '3':
                        return p => p.Price > intVal;
                    case '4':
                        return p => p.Price <= intVal;
                    case '5':
                        return p => p.Price >= intVal;
                    case '6':
                        return p => p.Price != intVal;
                    default:
                        throw new ArgumentException("Terrible terrible things...");
                }
            default:
                throw new ArgumentException("Terrible things are happening...");
        }
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

    public void AwaitUserInput(string message = "Press any key to continue...")
    {
        Console.WriteLine(message);
        Console.ReadKey();
    }

    public int PromptInt(int min = int.MinValue, int max = int.MaxValue)
    {
        string unformattedResult = Console.ReadLine()!;
        int result;
        while (true)
        {
            if (int.TryParse(unformattedResult, out result))
            {
                if (result < min)
                    PrintErrorMessage($"Integer should be greater than {min}.");
                else if (result > max)
                    PrintErrorMessage($"Integer should be less than {max}.");
                else
                    return result;
            }
            else
                PrintErrorMessage("Enter an integer!");
            unformattedResult = Console.ReadLine()!;
        }
    }

    public string PromptString()
    {
        string result = Console.ReadLine()!;
        while (string.IsNullOrEmpty(result))
        {
            PrintErrorMessage("Enter a string!");
            result = Console.ReadLine()!;
        }

        return result;
    }

    public void ClearWindow()
    {
        Console.Clear();
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
                PrintErrorMessage("Enter a decimal number!");
            unformattedResult = Console.ReadLine()!;
        }
    }

    //Destructors
}
