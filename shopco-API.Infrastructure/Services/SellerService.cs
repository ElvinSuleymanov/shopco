using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using shopco_API.Application.Interfaces;
using shopco_API.Domain.Entities;
using shopco_API.Domain.Models.SellerModels;
using shopco_API.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Infrastructure.Services
{
    public class SellerService : ISellerService
    {
        public ApplicationDbContext _db { get; set; }
        public IAuthenticationService authService { get; set; } 
        public  IWebHostEnvironment env { get; set; }
        public SellerService(ApplicationDbContext db, IAuthenticationService _authService,IWebHostEnvironment _env)
        {
            _db = db;
            authService = _authService;
            env = _env;
        }
        public async Task<LoginSellerResponse> Login(LoginSellerRequest req)
        {
            Seller seller = await _db.Sellers.Where<Seller>(seller =>
            seller.Email == req.Email
            ).FirstOrDefaultAsync();

            if (seller == null)
            {
                throw new Exception("User not found");
            }
            var token = await authService.generateJwt(seller);
     
            return new LoginSellerResponse { Status = 200, StatusMessage = "Operation Finished Successfully", JwtToken =token.JwtToken };
         }
     
        public async Task<RegisterSellerResponse> Register(RegisterSellerRequest req)
        {
        
            string FullNameFile = Guid.NewGuid().ToString() + Path.GetExtension(req.Photo.FileName) ;
            string sellerUrl = $"SellerPhotos/{FullNameFile}";
            string FileWillGenerated = Path.Combine(env.WebRootPath, "SellerPhotos", FullNameFile);
            using (FileStream fs = new FileStream(FileWillGenerated, FileMode.Create))
            {
                await req.Photo.CopyToAsync(fs);
            }
            Seller seller = new Seller { Email = req.Email,StoreName = req.Name ,PhotoUrl = sellerUrl, Role = 20};
            seller.SetHashedPassword(req.Password);
            await _db.Sellers.AddAsync(seller);
            await _db.SaveChangesAsync();
            return new RegisterSellerResponse { Status = 200, StatusMessage = "Operation Finished Successfully" };
        }
    }

}

