using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Nion.App.Models;
using Nion.App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nion.App.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly IAuthService _authService;

        [ObservableProperty] private string email;
        [ObservableProperty] private string password;
        [ObservableProperty] private string message;
        [ObservableProperty] private string emailError;
        [ObservableProperty] private string passwordError;

        public LoginViewModel(IAuthService authService)
        {
            _authService = authService;
        }

        [RelayCommand]
        private async Task LoginAsync()
        {
            EmailError = password = string.Empty;

            bool hasError = false;

            if (string.IsNullOrWhiteSpace(Email))
            {
                EmailError = "Email is required.";
                hasError = true;
            }
            else if (!Email.Contains("@"))
            {
                EmailError = "Invalid email format.";
                hasError = true;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                PasswordError = "Password is required.";
                hasError = true;
            }
            else if (Password.Length < 6)
            {
                PasswordError = "Password must be at least 6 characters.";
                hasError = true;
            }

            if (hasError) return;
            var response = await _authService.LoginAsync(new LoginModel
            {
                Email = email,
                Password = password
            });

            if (response != null && response.Success)
                message = "Login successful!";
            else
                message = response?.Message ?? "Login failed!";
        }
    }
}
