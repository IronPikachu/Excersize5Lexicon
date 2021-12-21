namespace Excersize_5_Lexicon.Extras;

internal interface ISave
{
    public void Save();
}

/*
    string fileName = "jsonfile.json";
    
    //Read to string from a file
    string jsonString = File.ReadAllText(fileName);
    
    //Serialize object
    string jsonString = JsonSerializer.Serialize(objectName); //Then you can write to file
    
    //Deserialize to object T
    T _t = JsonSerializer.Deserialize<T>(jsonString);
 
 */