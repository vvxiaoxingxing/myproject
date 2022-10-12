namespace Core.Jwt.Demo.Options
{
    public class JwtOptions
    {
        public const string Position = "JwtSettings";
        /// <summary>
        /// token是谁颁发的
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// token可以给哪些客户端使用
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// 加密的key
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// 几天过期
        /// </summary>
        public int ExpireDays { get; set; }

        /// <summary>
        /// 几小时过期
        /// </summary>
        public int ExpireHours { get; set; }

        /// <summary>
        /// 几分钟过期
        /// </summary>
        public int ExpireMinutes { get; set; }

        /// <summary>
        /// 几秒过期
        /// </summary>
        public int ExpireSeconds { get; set; }
    }
}
