using shopco_API.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shopco_API.Application.Interfaces;
using shopco_API.Domain.Models.AccountModels;
using shopco_API.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Security.Authentication;
using shopco_API.Domain.Models.WishlistModels;

namespace shopco_API.Infrastructure.Services
{
    public class AccountService:IAccountService
    {
        private ApplicationDbContext _db { get; set; }
        private IWebHostEnvironment _env { get; set; }
        public IAuthenticationService authService { get; set; }
        public AccountService(ApplicationDbContext db,IWebHostEnvironment env, IAuthenticationService _authService)
        {
            _db = db;
            _env = env;
            authService = _authService; 
        }
        public async Task<RegisterResponse> RegisterUser(RegisterRequest request)
        {


            var Existance = await _db.Users.Where<User>(user => user.Email == request.Email).FirstOrDefaultAsync();

            if (Existance != null)
            {
                throw new Exception("User Already Exist");
            }
           


            string guid = Guid.NewGuid().ToString();
            string fileAddress = guid + Path.GetExtension(request.Photo.FileName);

            
            string wwwrootPath = _env.WebRootPath;
            string photosPath = Path.Combine(_env.WebRootPath,"photos",fileAddress);
            string userPhotoPath = $"photos/{fileAddress}";
            using (FileStream fs = new FileStream(photosPath, FileMode.Create)) {
                await request.Photo.CopyToAsync(fs);
            }


            User newUser = new User { Email = request.Email,Name = request.Name,Surname = request.Surname,PhotoUrl = userPhotoPath, Role = 30 };
            newUser.SetHashedPassword(request.Password);
            _db.Users.Add(newUser);
            await  _db.SaveChangesAsync();
            return new RegisterResponse();
        }
        public async Task<LoginResponse> LoginUser(LoginRequest request)
        {
           User targetUser = await _db.Users.Where<User>(entity => entity.Email == request.Email).FirstOrDefaultAsync();
           bool isAuth = targetUser.isAuthenticated(request.Password);
           var generatedJwt = await authService.generateJwt(targetUser);

            if (isAuth)
            {
                return new LoginResponse { JwtToken = generatedJwt.JwtToken,StatusCode = 200,StatusMessage = "Operation Finished Successfully" };
            }
            else
            {
                throw new AuthenticationException();
            }
        }
        public async Task<GetAccountResponse> GetUserById(int Id)
        {
           User selected = await _db.Users.FindAsync(Id);
            AccountResponse res = new AccountResponse { Email = selected.Email, Id = selected.Id, Surname = selected.Surname, Name = selected.Name, PhotoUrl = selected.PhotoUrl, UserRole = selected.Role };
            return new GetAccountResponse{ Message = "Operation Finished Successfully", StatusCode = 200, User = res};
        }
        public async Task<AddWishlistResponse> AddToWishlist(AddWishlistRequest request)
        {
            UserWishlist uw = new UserWishlist { ProductId = request.ProductId, UserId = request.UserId};
            await  _db.UserWishlists.AddAsync(uw);
            await  _db.SaveChangesAsync();


            return new AddWishlistResponse { StatusCode = 200 };

        }
        public async Task<GetUserWishlistResponse> GetUserWishlist(GetUserWishlistRequest Request)
        {
            List<Product> Products = await _db.UserWishlists
                .Where<UserWishlist>(uw => Request.ProductId != null ? uw.ProductId == Request.ProductId && uw.UserId == Request.UserId
                :
                uw.UserId == Request.UserId
                ).Select<UserWishlist,Product>(entity => entity.Product).ToListAsync<Product>();

                
                
            return new GetUserWishlistResponse { StatusCode = 200 ,Products = Products };
        }
        public async Task<DeleteUserWishlistResponse> DeleteUserWishlist(DeleteUserWishlistRequest Request)
        {
           var selected = await _db.UserWishlists.Where<UserWishlist>(entity => entity.UserId == Request.UserId && entity.ProductId == Request.ProductId).FirstOrDefaultAsync<UserWishlist>();
            if (selected == null) {
                throw new Exception("Something unknown happened");
            }
            _db.UserWishlists.Remove(selected);
            await _db.SaveChangesAsync();
            return new DeleteUserWishlistResponse { StatusCode = 200 };
        }
    }
}
