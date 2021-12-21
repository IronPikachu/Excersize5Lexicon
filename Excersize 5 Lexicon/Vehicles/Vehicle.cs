﻿namespace Excersize_5_Lexicon.Vehicles;

public abstract class Vehicle
{
    //Fields
    private string registryNumber;
    private string ownerName;
    private string color;
    private int amountOfWheels;
    private int price;

    //Propertys
    public string RegistryNumber
    {
        get { return registryNumber; }
        private set
        {
            registryNumber = value ?? throw new ArgumentNullException($"RegistryNumber cannot be null!");
        }
    }
    public string OwnerName
    {
        get { return ownerName; }
        private set
        {
            ownerName = value ?? throw new ArgumentNullException($"OwnerName cannot be null!");
        }
    }
    public string Color
    {
        get { return color; }
        private set
        {
            color = value ?? throw new ArgumentNullException($"Color cannot be null!");
        }
    }
    public int AmountOfWheels
    {
        get { return amountOfWheels; }
        private set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException($"RegistryNumber cannot be less than zero!");
            amountOfWheels = value;
        }
    }
    public int Price
    {
        get { return price; }
        private set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException($"Price cannot be less than zero!");
            price = value;
        }
    }

    //Constructors
    public Vehicle(string registryNumber, string ownerName, string color, int amountOfWheels, int price)
    {
        RegistryNumber = registryNumber;
        OwnerName = ownerName;
        Color = color;
        AmountOfWheels = amountOfWheels;
        Price = price;
    }

    //Public Methods
    public override string ToString()
    {
        return $"Registry Number: {RegistryNumber}, owned by {OwnerName}, is a {Color} color and has {AmountOfWheels} wheels. It's price is {Price}.";
    }

    //Private Methods


    //Destructors


}