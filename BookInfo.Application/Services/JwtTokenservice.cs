//using Microsoft.Extensions.Configuration;
using BookInfo.Application.Interfaces;
using BookInfo.Domain.Entities.Identities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Application.Services
{
    public class JwtTokenservice :IJwtTokenService
    {

        private readonly SymmetricSecurityKey _key;
        private readonly SymmetricSecurityKey _encriptionkey;

        private readonly UserManager<AppUser> _userManager;
        public JwtTokenservice(IConfiguration config , UserManager<AppUser> userManager)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["SecretKey"]));
            _encriptionkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["EncrypKey"]));
            _userManager = userManager;

        }

        public async Task<string> CreateToken(AppUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var claim = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.NameId,user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),

            };

            claim.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)));


            SecurityTokenDescriptor security = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claim),
                SigningCredentials = new SigningCredentials(_key,SecurityAlgorithms.HmacSha512Signature),
                //EncryptingCredentials=new EncryptingCredentials(_encriptionkey,SecurityAlgorithms.HmacSha256Signature),
                EncryptingCredentials = new EncryptingCredentials(_encriptionkey,SecurityAlgorithms.Aes128KW,SecurityAlgorithms.Aes128CbcHmacSha256),
                Expires = DateTime.Now.AddDays(7),
            };
            var tokenHandler = new JwtSecurityTokenHandler();
           var token= tokenHandler.CreateToken(security);
            return tokenHandler.WriteToken(token);
        }


    }
}

