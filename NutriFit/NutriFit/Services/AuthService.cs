using Shared.DTOs;

namespace NutriFit.Services;

public class AuthService
{
    public async Task<bool> LoginAsync(string email, string password)
    {
        if (email == "test@test.com" && password == "123456")
        {
            await SecureStorage.SetAsync("authToken", "dummy_token");
            return true;
        }
        return false;
    }

    public async Task<bool> RegisterAsync(UserRegisterDto dto)
    {
        if (string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.Password))
            return false;

        return true;
    }

    public async Task LogoutAsync()
    {
        await SecureStorage.SetAsync("authToken", null);
    }
}
