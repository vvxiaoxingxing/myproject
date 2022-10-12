using Core.Jwt.Demo.Options;
using IdentityModel;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Jwt.Demo.Services
{
    public class TokenServices
    {
        JwtOptions _jwtSettings;
        public TokenServices(IOptions<JwtOptions> options)
        {
            _jwtSettings = options.Value;
        }

        public async Task<string> GetToken()
        {
            var result =  GeneToken("小星星","1993",true);
            return result.Item1;
        }

        private Tuple<string, DateTime> GeneToken(string nickName, string id, bool isAuthed)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSettings.SecretKey);
            var authTime = DateTime.UtcNow;//授权时间
            var expiresAt = authTime
                .AddDays(_jwtSettings.ExpireDays)
                .AddHours(_jwtSettings.ExpireHours)
                .AddMinutes(_jwtSettings.ExpireMinutes)
                .AddSeconds(_jwtSettings.ExpireSeconds);//过期时间
            var tokenDescripor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(JwtClaimTypes.Audience,_jwtSettings.Audience),
                    new Claim(JwtClaimTypes.Issuer,_jwtSettings.Issuer),
                    new Claim(JwtClaimTypes.Name, nickName??""),//result.WeChatNickName),
                    new Claim(JwtClaimTypes.Id,id),// result.ID.ToString()),
                    new Claim("AuthRole",isAuthed.ToString())
                }),
                Expires = expiresAt,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescripor);
            var tokenString = tokenHandler.WriteToken(token);
            return Tuple.Create(tokenString, expiresAt);


        }
    }
}
