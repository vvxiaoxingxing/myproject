using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NetCore.Core.Lib.JWT.Config;
using NetCore.Core.Lib.JWT.Model;
using NetCoreDemo.App.Extensions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreDemo.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly JWTOptions _jwtOptions;
        public HomeController(IOptions<JWTOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }
        /// <summary>
        /// 获取JwtToken
        /// </summary>
        /// <returns></returns>
        [Route("Home/Token")]
        [HttpPost]
        public ActionResult<string> GetJWTToken(JwtModel req)
        {
            string jwtToken = JWTExtesion.GetToken(req, _jwtOptions);
            return Ok(jwtToken);
        }

        
    }
}
