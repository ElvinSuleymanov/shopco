using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Domain.Entities
{
    public class Product
    {

        public int Id { get; set; }
        public int CategorieId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }  
        public string ProductImageUrl { get; set; }
        public DateTime CreatedAt { get => DateTime.Now; }
        public ICollection<UserWishlist> UserWishlists { get; set; }
    }
}
