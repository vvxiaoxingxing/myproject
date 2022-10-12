using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Core.Lib.JWT.Config
{
    public class JWTOptions
    {
        /// <summary>
        /// Jwt 的签名 密钥
        /// </summary>
        public string JwtSignInKey { get; set; }
        /// <summary>
        /// token 过期时间
        /// </summary>
        public long JwtExpireSeconds { get; set; }
    }
}
