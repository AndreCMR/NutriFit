using NutriFit.Services;
using System.Windows.Input;

namespace NutriFit.ViewModels;

public class LoginViewModel 
{
    public string Email { get; set; }
    public string Password { get; set; }
    public ICommand LoginCommand { get; }

    private readonly AuthService _authService;

    public LoginViewModel(AuthService authService)
    {
        _authService = authService;
        LoginCommand = new Command(async () => await LoginAsync());
    }

    private async Task LoginAsync()
    {
        var success = await _authService.LoginAsync(Email, Password);
        if (!success)
           // ShowError("Invalid credentials");
    }
}
