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
    public partial class RegisterViewModel : ObservableObject
    {
        private readonly IAuthService _authService;

        [ObservableProperty] private string firstName;
        [ObservableProperty] private string lastName;
        [ObservableProperty] private string email;
        [ObservableProperty] private string password;
        [ObservableProperty] private string message;

        public RegisterViewModel(IAuthService authService)
        {
            _authService = authService;
        }

        [RelayCommand]
        private async Task RegisterAsync()
        {
            var response = await _authService.RegisterAsync(new RegisterModel
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            });

            if (response != null && response.Success)
                message = "Registration successful!";
            else
                message = response?.Message ?? "Registration failed!";
        }
    }
}
