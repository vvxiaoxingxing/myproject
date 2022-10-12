using Core.Jwt.Demo.Attributes;
using Core.Jwt.Demo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Core.Jwt.Demo.Controllers
{
    [ApiController]
    
    public class TokenController : ControllerBase
    {
        private readonly TokenServices _services;
        public TokenController(TokenServices services)
        {
            _services = services;
        }
        [Route("Token/Get")]
        [HttpGet]
        [IgnoreAction]
        public async Task<string> GetToken()
        {
            return await _services.GetToken();
        }
    }
}
