using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using shopco_API.Application.Interfaces;
using shopco_API.Domain.Entities;
using shopco_API.Domain.Models.ProductModels;
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
        public async Task<(string, Guid)> GenerateFile(IFormFile file)
        {
            string FileName = "Products/" +  Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string wwwRootPath = Path.Combine(env.WebRootPath,FileName);
            using (FileStream fs = new(wwwRootPath,FileMode.Create))
            {
               await file.CopyToAsync(fs);
            }
            return (FileName, Guid.NewGuid());
        }
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
            var isSellerExist = await _db.Sellers.Where<Seller>(seller => seller.Email == req.Email).FirstOrDefaultAsync<Seller>();
            if (isSellerExist != null)
            {
                throw new Exception("User Already Exist");
            }

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
        public async Task<AddProductResponse> AddProduct(AddProductRequest req)
        {
            var filePath = await GenerateFile(req.ProductPhoto);
            
            Product product = new Product { CategorieId = req.CategorieId, Description = req.Description, Price = req.Price,
                ProductName = req.ProductName, ProductImageUrl = filePath.Item1
            };
           await _db.Products.AddAsync(product);
           await _db.SaveChangesAsync();
           
            SellerProduct relational = new SellerProduct { SellerId = req.SellerId,ProductId = product.Id };
            await _db.SellerProducts.AddAsync(relational);
            await _db.SaveChangesAsync();

            return new AddProductResponse { StatusCode = 200 };
        }
        public async Task<GetProductResponse> GetProductById(GetProductRequest request)
        {
            var sellersProducts =  await _db.SellerProducts.Where<SellerProduct>(s => request.ProductId != null 
            ? s.ProductId == request.ProductId && s.SellerId == request.SellerId
            : s.SellerId == request.SellerId)
            .Select<SellerProduct,Product>(entity => entity.Product).ToListAsync();


           return new GetProductResponse { StatusCode= 200,Products = sellersProducts };
        }
    }

}

