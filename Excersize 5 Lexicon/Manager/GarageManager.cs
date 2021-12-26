using Excersize_5_Lexicon.Handlers;
using Excersize_5_Lexicon.UIs;
using Excersize_5_Lexicon.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Excersize_5_Lexicon.Manager;

public class GarageManager
{
    //Fields
    private IUI ui;
    private List<IHandler<IVehicle>> handlers = new();
    private List<string> availableVehicles = new List<string> { "Airplane", "Boat", "Bus", "Car", "Motorcycle", "Unicycle" };

    //Propertys


    //Constructors
    public GarageManager()
    {
        Console.Write("Please enter your name: ");
        ui = new UI(Console.ReadLine()!);
    }

    //Public Methods
    public void Main()
    {
        bool run = true;
        ui.Greetings();
        ui.AwaitUserInput();
        Console.ReadKey();
        while (run)
        {
            char[] options = { '0', '1', '2', '3', '4', '5' };
            char option = ui.MainMenu(handlers.Count, options);
            switch (option)
            {
                case '0':   //Exit the program
                    run = false;
                    ui.Farewell();
                    break;
                case '1':   //Add a garage
                    AddGarage();
                    break;
                case '2':   //Add a vehicle
                    AddVehicle();
                    break;
                case '3':   //Remove a vehicle
                    RemoveVehicle();
                    break;
                case '4':   //Find a vehicle
                    FindVehicle();
                    break;
                case '5':   //List all vehicles
                    ListVehicles();
                    break;
                default:    //wtf?
                    ui.PrintErrorMessage("Wrong option somehow happened..?");
                    break;
            }
        }
    }

    //Private Methods
    private void AddGarage()
    {
        char[] options = { '0', '1', '2', '3' };
        char[] vOptions = new char[availableVehicles.Count];
        for (int i = 0; i < availableVehicles.Count; i++)
            vOptions[i] = $"{i + 1}"[0];
        char option = ui.AddGarageMenu(options);
        switch (option)
        {
            case '0':   //Exit to main menu, do nothing
                break;
            case '1':   //Start a garage with a set capacity
                AddGarageUserInput(vOptions);
                break;
            case '2':   //Start a garage with a set capacity and vehicles
                AddGarageUserInput(vOptions);
                ui.PrintMessage("Please enter how many vehicles to add: ");
                int maxVehicleAmount = handlers[handlers.Count - 1].MaxCapacity;
                int add = ui.PromptInt(max: maxVehicleAmount);
                for (int i = 0; i < add; i++)
                {
                    AddVehicle(handlers.Count - 1);
                }
                break;
            case '3':   //Read garage from json
                throw new NotImplementedException("This is not implemented yet, if ever!!!");
            //break;
            default:
                ui.PrintErrorMessage("Bruh wat..?");
                break;
        }
    }

    private void AddGarageUserInput(char[] vOptions)
    {
        char vOption = ui.TypeOfVehicleMenu(vOptions, availableVehicles);
        if (vOption == '0') //Exit to main menu
            return;
        string name = ui.GetGarageNameFromUser("Enter the name of the garage:");
        int size = ui.GetCapacityFromUser("Enter the garages capacity:");
        switch (vOption)
        {
            case '1':   //Airplane
                handlers.Add(new Handler<Airplane>(name, size));
                break;
            case '2':   //Boat
                handlers.Add(new Handler<Boat>(name, size));
                break;
            case '3':   //Bus
                handlers.Add(new Handler<Bus>(name, size));
                break;
            case '4':   //Car
                handlers.Add(new Handler<Car>(name, size));
                break;
            case '5':   //Motorcycle
                handlers.Add(new Handler<Motorcycle>(name, size));
                break;
            case '6':   //Unicycle
                handlers.Add(new Handler<Unicycle>(name, size));
                break;
            case '7':   //Everything - Vehicle
                handlers.Add(new Handler<Vehicle>(name, size));
                break;
            default:
                ui.PrintErrorMessage("Nani the fuck");
                break;
        }
    }

    private void AddVehicle()
    {
        List<string> names = handlers.Select(p => p.GarageName).ToList();
        int index = ui.AddVehicleMenu(names);
        if (index == 0)
            return;
        AddVehicle(index - 1);
    }

    private void AddVehicle(int handlerIndex)
    {
        Type type = handlers[handlerIndex].GetGenericType();
        IVehicle newVehicle;
        try
        {
            newVehicle = ui.GetVehicleFromUser(type);
            if (!handlers[handlerIndex].AddVehicle(newVehicle))
            {
                ui.PrintErrorMessage($"{handlers[handlerIndex].GarageName} is full and couldn't recieve more {type.Name}s.");
            }
            else
            {
                ui.PrintMessage($"Successfully added {type.Name} to {handlers[handlerIndex].GarageName}.");
            }
        }
        catch (Exception ex)
        {
            ui.PrintErrorMessage(ex.Message);
        }
        ui.AwaitUserInput();
    }

    private void RemoveVehicle()
    {
        List<string> names = handlers.Select(p => p.GarageName).ToList();
        int index = ui.RemoveVehicleMenu(names);
        if (index == 0)
            return;
        RemoveVehicle(index - 1);
    }

    private void RemoveVehicle(int handlerIndex)
    {
        Type type = handlers[handlerIndex].GetGenericType();
        IVehicle vehicleToRemove = ui.GetVehicleFromUser(type);
        if (!handlers[handlerIndex].RemoveVehicle(vehicleToRemove))
        {
            ui.PrintErrorMessage($"The {type.Name} you want to remove does not exist in {handlers[handlerIndex].GarageName}.");
        }
        else
        {
            ui.PrintMessage($"Succesfully removed the {type.Name} from {handlers[handlerIndex].GarageName}.");
        }
        ui.AwaitUserInput();
    }

    private void FindVehicle()
    {
        List<Func<IVehicle, bool>> list = new();
        Dictionary<string, IEnumerable<IVehicle>> found = new(); //TODO: Copy list but let them have the same references, but the 'found' list should be changed while 'handlers' should be unchanged
        /*
        p => p.Thing == anotherThing
        Func<T, bool>(T p) {return p.Thing == anotherThing;}
         */
        string input;
        bool loop = true;
        do
        {
            ui.ClearWindow();
            ui.PrintMessage($"Type 'Exit' to exit, or anything to add another attribute...");
            input = ui.PromptString();
            if (input == "Exit")
                loop = false;
            else
                list.Add(ui.FindPredicateFromUser());

        } while (loop);

        for (int i = 0; i < handlers.Count; i++)
        {
            found.Add(handlers[i].GarageName, handlers[i].SearchVehicles(x =>
            {
                bool result = true;
                foreach (var f in list)
                {
                    result &= f(x);
                    if (!result)
                        return false;
                }
                return true;
            }));
        }

        ui.ClearWindow();

        if (found.Count > 0)
            ui.PrintMessage("Here's what i found:\n");
        else
        {
            ui.PrintMessage("Nothing found mathing those parameters...");
            ui.AwaitUserInput();
            return;
        }
        foreach (var sak in found)
        {
            if(sak.Value.Count() > 0)
            {
                foreach(var vehicle in sak.Value)
                {
                    ui.PrintMessage($"{vehicle}\nExists in the {sak.Key} garage.");
                }
            }
        }
        ui.AwaitUserInput();
    }

    private void ListVehicles() //TODO: Fix this shit it's not good
    {
        ui.ClearWindow();
        foreach (var handler in handlers)
        {
            foreach (var vehicle in handler)
            {
                ui.PrintMessage($"{vehicle} \n\texists in the {handler.GarageName} garage.\n\n");
            }
        }
        ui.AwaitUserInput();
    }

    //Destructors
}
