namespace DelegatesAndEvents;

public class Button
{
    public event EventHandler<ButtonPressedEventArgs>? ButtonPressed;
    
    public void OnButtonPressed(char keyCode)
    {
        ButtonPressed?.Invoke(this, new ButtonPressedEventArgs(keyCode));
    }
}

public class ButtonPressedEventArgs
{
    public ButtonPressedEventArgs(char keyCode)
    {
        KeyCode = keyCode;
    }
    public char KeyCode { get; private set;}
} 
