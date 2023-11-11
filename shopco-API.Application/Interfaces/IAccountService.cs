
using shopco_API.Domain.Models.AccountModels;
using shopco_API.Domain.Models.WishlistModels;
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
        public Task<AddWishlistResponse> AddToWishlist(AddWishlistRequest req);
        public Task<GetUserWishlistResponse> GetUserWishlist(GetUserWishlistRequest req);
        public Task<DeleteUserWishlistResponse> DeleteUserWishlist(DeleteUserWishlistRequest req);
    }
}
