using Core.Jwt.Demo.Attributes;
using IdentityModel;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Jwt.Demo.Filters
{

    public class AuthFilters : IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (!IsIgnoreAction(context.ActionDescriptor as ControllerActionDescriptor))
            {
                //do thing
                var users = context.HttpContext.User.Identities;
                long userId = 0;
                foreach (var item in users)
                {
                    var a = item.Claims.FirstOrDefault(c => c.Type.Equals(JwtClaimTypes.Id, StringComparison.OrdinalIgnoreCase))?.Value != null;
                    if (a)
                    {
                        long.TryParse(item.Claims?.FirstOrDefault(c => c.Type.Equals(JwtClaimTypes.Id, StringComparison.OrdinalIgnoreCase))?.Value, out userId);
                    }
                    else
                    {
                        //没有解析到就表示过期了。。。返回错误信息
                        throw new Exception("Token 过期啦");
                    }
                }
            }
        }
        /// <summary>
        /// 是否是忽略得
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        private bool IsIgnoreAction(ControllerActionDescriptor descriptor)
        {
            return descriptor.ControllerTypeInfo.CustomAttributes.Any(x => typeof(IgnoreActionAttribute).IsAssignableFrom(x.AttributeType)) ||
            descriptor.MethodInfo.CustomAttributes.Any(x => typeof(IgnoreActionAttribute).IsAssignableFrom(x.AttributeType));
        }
    }
}
