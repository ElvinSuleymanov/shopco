using Microsoft.EntityFrameworkCore;
using shopco_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Infrastructure.DataBase
{
    public class ApplicationDbContext : DbContext

    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users {get;set;}
        public DbSet<Seller> Sellers { get;set;}
        public DbSet<Product> Products { get;set;}
        public DbSet<UserWishlist> UserWishlists { get;set;}
        public DbSet<SellerProduct> SellerProducts { get;set;}  

    }
}
