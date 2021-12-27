using Excersize_5_Lexicon.Manager;
using System.IO;

if (!Directory.Exists(@"SavedObjects"))
    Directory.CreateDirectory(@"SavedObjects");

GarageManager manager = new GarageManager();
manager.Main();