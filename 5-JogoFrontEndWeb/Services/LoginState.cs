namespace _5_JogoFrontEndWeb.Services
{
    public class LoginState
    {
        public bool IsLoggedIn { get; private set; } = false;

        public event Action? OnChange;

        public void Login()
        {
            IsLoggedIn = true;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
