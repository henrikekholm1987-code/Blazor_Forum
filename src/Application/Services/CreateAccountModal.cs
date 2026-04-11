namespace Application.Services;

public class CreateAccountModalState
{
    public bool Visible { get; private set; }

    public event Action? OnChange;

    public void Show()
    {
        Visible = true;
        NotifyStateChanged();
        
        // UserService.CreateUser();
    }

    public void Close()
    {
        Visible = false;
        NotifyStateChanged();
    }

    private void NotifyStateChanged()
    {
        OnChange?.Invoke();
    }
}