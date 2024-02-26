namespace DelegatesAndEvents;

public delegate void EventNotifyDelegate(NumberEventArgs args);

public abstract class EventNotifierBase
{
    public abstract void Notify(NumberEventArgs args);
}

public class EventNotify : EventNotifierBase
{
    public override void Notify(NumberEventArgs args)
    {
        Console.WriteLine($"EventNotify: Even number: {args.Message} found!");
    }
}

public class EventNotify2 : EventNotifierBase
{
    public override void Notify(NumberEventArgs eventArgs)
    {
        Console.WriteLine($"EventNotify2: Even number: {eventArgs.Message} found!");
    }
   
}

public class NumberEventArgs
{
    public int Message { get; set; }
}
