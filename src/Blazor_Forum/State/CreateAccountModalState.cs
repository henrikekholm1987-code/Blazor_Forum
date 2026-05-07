
public class CreateAccountModalState
{
    public event Action? OnShow;
    public event Action? OnClose;

    public void Show()
    {
        OnShow?.Invoke();
    }
    public void Close()
    {
        OnClose?.Invoke();
    }
}

// public class CreateThreadModalState
// {
//     public event Action? Show;
//     public event Action? Close;
//
//     public void sShow()
//     {
//         Show?.Invoke();
//     }
//     public void cClose()
//     {
//         Close?.Invoke();
//     }
// }