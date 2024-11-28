using NutriFit.Services;
using Shared.DTOs;
using System.Windows.Input;

namespace NutriFit.ViewModels;

public class RegisterViewModel 
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }
    public ICommand RegisterCommand { get; }

    private readonly AuthService _authService;

    public RegisterViewModel(AuthService authService)
    {
       _authService = authService;
        RegisterCommand = new Command(async () => await RegisterAsync());
    }

    private async Task RegisterAsync()
    {
        var dto = new UserRegisterDto
        {
            Name = Name,
            Email = Email,
            Password = Password,
            Weight = Weight,
            Height = Height
        };

        var success = await _authService.RegisterAsync(dto);
        if (!success)
           // ShowError("Registration failed");
    }
}
