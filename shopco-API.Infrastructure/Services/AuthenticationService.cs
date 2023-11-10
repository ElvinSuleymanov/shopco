using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using shopco_API.Application.Interfaces;
using shopco_API.Domain.Entities;
using shopco_API.Domain.Models.AccountModels;
using shopco_API.Domain.Models.AuthenticationModels;
using shopco_API.Domain.Models.SellerModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public IConfiguration configuration { get; set; }    
        public AuthenticationService(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public async Task<AuthenticationResult> authorizeJwt(string Jwt)
        {

            string DefaultIssuer = configuration["Jwt:Issuer"];
            string DefaultAudience = configuration["Jwt:Audience"];
            string DefaultKey = configuration["Jwt:Key"];
            byte[] bytes = Encoding.UTF8.GetBytes(DefaultKey);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            var result = handler.ValidateToken(Jwt,new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(bytes)
            },out var validation);
           
            if (validation != null)
            {
                return new AuthenticationResult { StatusMessage = "Operation is Finished Successfully", StatusCode = 200, isSuccess = true };
            }
           throw new SecurityTokenInvalidSigningKeyException();
        }


        public async Task<LoginResponse> generateJwt(User user)
        {
            
            string DefaultIssuer = configuration["Jwt:Issuer"];
            string DefaultAudience = configuration["Jwt:Audience"];
            string DefaultKey = configuration["Jwt:Key"];

            ClaimsIdentity claims = new();
            claims.AddClaim(new Claim("Id", user.Id.ToString()));
            claims.AddClaim(new Claim("Name", user.Name));
            claims.AddClaim(new Claim("Surname", user.Surname));
            claims.AddClaim(new Claim("Role",user.Role.ToString()));
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(DefaultKey));
            SigningCredentials credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha512); 

            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor { Subject = claims};
            descriptor.Issuer = DefaultIssuer;
            descriptor.Audience = DefaultAudience;
            descriptor.SigningCredentials = credentials;
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(descriptor);
           string jwtToken = handler.WriteToken(token);

            return new LoginResponse { JwtToken = jwtToken, StatusCode = 200, StatusMessage = "Operation Finished Successfully" };
        }



        public async Task<LoginSellerResponse> generateJwt(Seller user)
        {

            string DefaultIssuer = configuration["Jwt:Issuer"];
            string DefaultAudience = configuration["Jwt:Audience"];
            string DefaultKey = configuration["Jwt:Key"];

            ClaimsIdentity claims = new();
            claims.AddClaim(new Claim("Id", user.Id.ToString()));
            claims.AddClaim(new Claim("Name", user.StoreName));
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(DefaultKey));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor { Subject = claims };
            descriptor.Issuer = DefaultIssuer;
            descriptor.Audience = DefaultAudience;
            descriptor.SigningCredentials = credentials;
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(descriptor);
            string jwtToken = handler.WriteToken(token);

            return new LoginSellerResponse { JwtToken = jwtToken, Status = 200, StatusMessage = "Operation Finished Successfully" };
        }
    }
}
