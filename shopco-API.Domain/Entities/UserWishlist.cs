using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Domain.Entities
{
    public class UserWishlist
    {
        public int Id { get; set; } 
        public int UserId { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }  
        public int ProductId { get; set; }
    }
}
