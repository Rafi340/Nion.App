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

        public LoginViewModel(IAuthService authService)
        {
            _authService = authService;
        }

        [RelayCommand]
        private async Task LoginAsync()
        {
            try
            {
                var response = await _authService.LoginAsync(new LoginModel
                {
                    Email = email,
                    Password = password
                });

                if (response != null && response.Success)
                {
                    Message = "Login successful!";
                    Application.Current.MainPage = new NavigationPage(new MainPage());
                }
                else
                {
                    Message = response?.Message ?? "Login failed!";
                }
            }
            catch (Exception ex)
            {
                Message = $"Error: {ex.Message}";
            }
        }
    }
}
