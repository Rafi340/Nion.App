using Nion.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nion.App.Services
{
    public interface IAuthService
    {
        Task<AuthResponse?> LoginAsync(LoginModel request);
        Task<AuthResponse?> RegisterAsync(RegisterModel request);
    }
}
