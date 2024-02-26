using System.Runtime.Loader;
using DelegatesAndEvents;

//Delegates.Run();

//Create an instance of the delegate and assign a method to it

var myClass = new EventNotify();
EventNotifyDelegate eventNotifyDelegate = new EventNotifyDelegate(myClass.Notify);
RunCallback(eventNotifyDelegate);

Console.WriteLine("--------------------------------------------------");
//This is the same as the above but using a different syntax
EventNotifyDelegate eventNotify = new EventNotify2().Notify;
RunCallback(eventNotify);

var button = new Button();
button.ButtonPressed += (sender, eventArgs) =>
{
    Console.WriteLine($"Button Pressed keycode: {eventArgs.KeyCode}");
};

Start:

var keyCode = Console.ReadKey().KeyChar;

button.OnButtonPressed(keyCode);

goto Start;


static void RunCallback(EventNotifyDelegate raiseEvent)
{
    var numbers = new int[50];
    
    for (int number = 0; number < numbers.Length; number++)
    {
        if (number % 2 == 0)
        {
            raiseEvent.Invoke(new NumberEventArgs() { Message = number});
        }
    }
   
}




