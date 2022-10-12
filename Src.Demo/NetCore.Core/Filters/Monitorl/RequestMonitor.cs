using Microsoft.Extensions.Logging;
using NetCore.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Core.Filters.Monitorl
{
    /// <summary>
    /// 接口请求监视器
    /// </summary>
    public class RequestMonitor : IDisposable
    {
        DateTime beginTime = DateTime.Now;
        private readonly ILogger _loger;
        private StringBuilder _message = new StringBuilder();

        public RequestMonitor(ILogger loger)
        {
            this._loger = loger;
        }

        public static RequestMonitor Start(ILogger loger)
        {
            return new RequestMonitor(loger);
        }

        public void Push(string message)
        {
            _message.Append(message);
        }
        public void Push(object content)
        {
            _message.Append(JsonSerializerUtility.EscSerialize(content));
        }
        public void Dispose()
        {
            DateTime endTime = DateTime.Now;
            double milliseconds = (endTime - beginTime).TotalMilliseconds;
            this._loger.LogInformation($"{_message.ToString()},花费时间(毫秒):{milliseconds},{(milliseconds > 2000 ? "时间过长" : "")}");
            _message.Clear();
            _message = null;
        }
    }
}
