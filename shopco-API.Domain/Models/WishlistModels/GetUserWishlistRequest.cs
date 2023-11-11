using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Domain.Models.WishlistModels
{
    public class GetUserWishlistRequest
    {
        public int UserId { get; set; }
        public int? ProductId { get; set; }
    }
}
