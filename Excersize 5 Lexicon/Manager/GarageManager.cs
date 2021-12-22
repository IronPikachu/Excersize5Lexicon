using Excersize_5_Lexicon.Handlers;
using Excersize_5_Lexicon.UIs;
using Excersize_5_Lexicon.Vehicles;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Excersize_5_Lexicon.Manager;

public class GarageManager
{
    //Fields
    private IUI ui;
    private List<IHandler<IVehicle>> handlers = new();// List<IHandler<IVehicle>>();
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
        Console.Write("Press any key to continue...");
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
            vOptions[i] = $"{i}"[0];
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
                int add = ui.PromptInt(maxVehicleAmount);
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

    }

    private void AddVehicle(int handlerIndex)
    {
        Type type = handlers[handlerIndex].GetGenericType();
        IVehicle newVehicle = ui.GetVehicleFromUser<typeof(type)>();
        handlers[handlerIndex].AddVehicle(newVehicle);
    }

    private void RemoveVehicle()
    {

    }
    private void FindVehicle()
    {

    }
    private void ListVehicles()
    {
        foreach (var handler in handlers)
        {
            foreach (var vehicle in handler.GarageName)
            {
                ui.PrintMessage($"{vehicle} exists in the {handler.GarageName} garage");
            }
        }
    }

    //Destructors
}
