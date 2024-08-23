using System;

public class StartScreen : Window
{
    public event Action StartButtonClicked;
    
    public override void Open()
    {
        gameObject.SetActive(true);
    }

    public override void Close()
    {
        gameObject.SetActive(false);
    }

    protected override void ButtonClicked()
    {
        StartButtonClicked?.Invoke();
    }
}
