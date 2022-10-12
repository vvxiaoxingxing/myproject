using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetCore.Infrastructure.Extension
{
    public class HttpClientWrapperExtensions
    {
        private readonly IHttpClientFactory _factory;

        public HttpClientWrapperExtensions(IHttpClientFactory factory)
        {
            this._factory = factory;
        }

        public async Task<string> GetAsync(string url, Dictionary<string, string> parameters, int timeout)
        {
            if (parameters != null && parameters.Count > 0)
            {
                var args = new List<string>();
                foreach (var key in parameters.Keys)
                {
                    args.Add(string.Format("{0}={1}", key, parameters[key]));
                }
                url = string.Format("{0}?{1}", url, string.Join("&", args));
            }
            return await SendAsync(url, null, HttpMethod.Get, timeout);
        }

        public async Task<string> PostAsync(string url, string parameter, int timeout, string contentType = "application/x-www-form-urlencoded")
        {
            return await PostAsync(url, parameter, timeout, contentType, null);
        }

        public async Task<string> PostAsync(string url, string parameter, int timeout,
            string contentType, Dictionary<string, string> headers)
        {
            using var content = new StringContent(parameter);
            content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
            if (headers != null)
            {
                foreach (var item in headers)
                {
                    content.Headers.Add(item.Key, item.Value);
                }
            }
            return await SendAsync(url, content, HttpMethod.Post, timeout);
        }

        /// <summary>
        /// multipart/form-data
        /// </summary>
        /// <param name="url"></param>
        /// <param name="parameters"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public async Task<string> PostAsync(string url, Dictionary<string, object> parameters, int timeout)
        {
            using var content = new MultipartFormDataContent();

            foreach (var key in parameters.Keys)
            {
                var value = parameters[key];
                if (value is Action<MultipartFormDataContent>)
                {
                    var callback = value as Action<MultipartFormDataContent>;
                    callback(content);
                }
                else if (value is byte[])
                {
                    content.Add(new ByteArrayContent(value as byte[]), key, Guid.NewGuid().ToString()); //DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fffffff")
                }
                else
                {
                    content.Add(new StringContent(value.ToString()), key);
                }
            }

            return await SendAsync(url, content, HttpMethod.Post, timeout);
        }
        /// <summary>
        /// application/x-www-form-urlencoded
        /// </summary>
        /// <param name="url"></param>
        /// <param name="parameters"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public async Task<string> PostAsync(string url, Dictionary<string, string> parameters, int timeout)
        {
            using var content = new FormUrlEncodedContent(parameters);
            return await SendAsync(url, content, HttpMethod.Post, timeout);
        }
        async Task<string> SendAsync(string url, HttpContent content, HttpMethod method, int timeout)
        {
            using var client = _factory.CreateClient("custom");
            client.Timeout = TimeSpan.FromMilliseconds(timeout);

            using var request = new HttpRequestMessage(method, url);
            if (method == HttpMethod.Post)
            {
                request.Content = content;
            }

            var cancel = new CancellationTokenSource();

            string result = null;
            try
            {
                using var response = await client.SendAsync(request, cancel.Token);
                result = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                return result;
            }
            catch (HttpRequestException hex)
            {
                if (string.IsNullOrWhiteSpace(result))
                {
                    throw hex;
                }
                else
                {
                    throw new HttpRequestException(result, hex);
                }
            }
            catch (TaskCanceledException tex)
            {
                if (tex.CancellationToken != cancel.Token)
                {
                    throw new Exception("请求超时/错误", tex);
                }
                throw tex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
