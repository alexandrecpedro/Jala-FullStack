namespace DelegatesAndEvents;

// Delegates are used to pass methods as arguments to other methods
// Delegates can be used to define callback methods

// Delegates that do not return a value can be used as a type for a method that does not return a value
public delegate void MyDelegate();
public delegate void MyDelegateParameter(string name);

// Delegates that return a value can be used as a function pointer (a pointer to a method that returns a value)

public delegate string MyDelegateReturnParameter(int id);
public class Delegates
{
    public delegate string MyDelegateReturn();
    public static void  Run()
    {
        // Assign a method to the delegate and than invoke the delegate
        
        // Delegates can be chained together using += ; for example, multiple methods can be called on a single delegate event
        MyDelegate myVoidDelegate = MyVoidMethod;
        myVoidDelegate += MySecondVoidMethod;
        //The method MyMethod is called first and than the method MySecondMethod is called
        myVoidDelegate();
        
        // Now remove a method from the delegate and call the delegate again
        myVoidDelegate -= MySecondVoidMethod;
        // This time only the method MyVoidMethod is called
        myVoidDelegate();
      
        MyDelegateParameter myDelegateParameter = MyMethodParameter;
        MyDelegateReturn myDelegateReturn = MyMethodReturn;
        MyDelegateReturnParameter myDelegateReturnParameter = MyMethodReturnParameter;
        
        myDelegateParameter("MyMethodParameter");
        Console.WriteLine(myDelegateReturn());
        Console.WriteLine(myDelegateReturnParameter(1));
    }
    
    private static void MyVoidMethod()
    {
        Console.WriteLine("Hello from MyVoidMethod");
    }
    
    private static void MySecondVoidMethod()
    {
        Console.WriteLine("Hello from MySecondVoidMethod");
    }
    
    private static void MyMethodParameter(string name)
    {
        Console.WriteLine($"Hello from {name}");
    }

    private static string MyMethodReturn()
    {
        return "Hello from MyMethodReturn";
        //return string.Empty;
    }
    
    private static string MyMethodReturnParameter(int id)
    {
        return $"Hello from {id.ToString()}";
    }
}