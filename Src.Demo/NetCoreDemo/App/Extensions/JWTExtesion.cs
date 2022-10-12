using Microsoft.IdentityModel.Tokens;
using NetCore.Core.Lib.JWT.Config;
using NetCore.Core.Lib.JWT.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NetCoreDemo.App.Extensions
{
    public class JWTExtesion
    {
        public static string GetToken(JwtModel req, JWTOptions _jwtOptions)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, "1"));
            claims.Add(new Claim(ClaimTypes.Name, req.UserName));
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            string jwtToken = BuildToken(claims, _jwtOptions);
            return jwtToken;
        }


        private static string BuildToken(IEnumerable<Claim> claims, JWTOptions options)
        {
            DateTime expires = DateTime.Now.AddSeconds(options.JwtExpireSeconds);
            byte[] keyBytes = Encoding.UTF8.GetBytes(options.JwtSignInKey);
            var secKey = new SymmetricSecurityKey(keyBytes);
            var credentials = new SigningCredentials(secKey,
                SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(expires: expires,
                signingCredentials: credentials, claims: claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
