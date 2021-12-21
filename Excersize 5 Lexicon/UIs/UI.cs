namespace Excersize_5_Lexicon.UIs;

public class UI : IUI
{

    //Fields


    //Propertys
    public string UserName { get; }


    //Constructors
    public UI()
    {
        UserName = "Anonymous";
    }
    public UI(string name)
    {
        UserName = name;
    }


    //Public Methods



    //Private Methods
    void IUI.PrintErrorMessage(string message)
    {
        throw new NotImplementedException();
    }


    //Destructors
}
