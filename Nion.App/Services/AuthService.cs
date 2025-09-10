using Nion.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nion.App.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApiClient _apiClient;

        public AuthService()
        {
            _apiClient = new ApiClient();
        }

        public async Task<AuthResponse?> LoginAsync(LoginModel request)
        {
            return await _apiClient.PostAsync<AuthResponse>("api/auth", request);
        }

        public async Task<AuthResponse?> RegisterAsync(RegisterModel request)
        {
            return await _apiClient.PostAsync<AuthResponse>("auth/register", request);
        }
    }
}
