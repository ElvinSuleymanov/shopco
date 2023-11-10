using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Domain.Entities
{
    public class User
    {
        public int Id { get; set; } 
        public int Role { get; set; }
        public string Name { get; set; }    
        public string Surname { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<UserWishlist> WishList { get; set; }
        //public ICollection<Product> Cart { get; set; }
        public DateTime RegisteredAt { get => DateTime.Now; } 
        
        public void SetHashedPassword(string password)
        {

            using (var encoder = SHA256.Create())
            {
                string randomGuid = Guid.NewGuid().ToString();
                var salt =  encoder.ComputeHash(Encoding.UTF8.GetBytes(randomGuid));
                Salt = salt;

                HMACSHA256 generator = new (salt);
                
                byte[] arr =  generator.ComputeHash(Encoding.UTF8.GetBytes(password));
                Password = arr; 
            }
        }

        public bool isAuthenticated(string passw)
        {

            using (HMACSHA256  generator = new(this.Salt))
            {
               var arr = generator.ComputeHash(Encoding.UTF8.GetBytes(passw));
               return arr.SequenceEqual(this.Password);
            }
        }
    }
}
