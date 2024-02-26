namespace Exchange.Classes;

public abstract class Currency
{
    public string Name { get; }

    public Currency(string name)
    {
        Name = name;
    }
}