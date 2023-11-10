using shopco_API.Domain.Entities;
using shopco_API.Domain.Models.AccountModels;
using shopco_API.Domain.Models.AuthenticationModels;
using shopco_API.Domain.Models.SellerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Application.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<LoginResponse> generateJwt(User user);
        public Task<LoginSellerResponse> generateJwt(Seller user);
        public Task<AuthenticationResult> authorizeJwt(string Jwt);
    }
}
