using shopco_API.Domain.Models.SellerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Application.Interfaces
{
    public interface ISellerService
    {
        public Task<RegisterSellerResponse> Register(RegisterSellerRequest req);
        public Task<LoginSellerResponse> Login(LoginSellerRequest req);
        
    }
}
