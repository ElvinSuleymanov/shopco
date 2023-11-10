
using shopco_API.Domain.Models.AccountModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Application.Interfaces
{
    public interface IAccountService
    {
        public Task<RegisterResponse> RegisterUser(RegisterRequest request);
        public Task<LoginResponse> LoginUser(LoginRequest request);
        public Task<GetAccountResponse> GetUserById (int id);
    }
}
