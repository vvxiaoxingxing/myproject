using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreDemo.Controllers
{
    [ApiController]
    [Authorize]
    public class BaseApiController : ControllerBase
    {
    }
}
