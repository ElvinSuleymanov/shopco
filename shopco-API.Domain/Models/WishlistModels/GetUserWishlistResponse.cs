using shopco_API.Domain.Entities;
using shopco_API.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Domain.Models.WishlistModels
{
    public class GetUserWishlistResponse:BaseResponse
    {
        public List<Product> Products { get; set; }
    }
}
