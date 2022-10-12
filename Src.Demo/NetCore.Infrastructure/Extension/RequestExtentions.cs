using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NetCore.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NetCore.Infrastructure.Extension
{
    public static class RequestExtentions
    {
        public static async Task<string> GetParameters(this HttpRequest request)
        {
            if (request.Method.Equals("get", StringComparison.OrdinalIgnoreCase))
            {
                Dictionary<string, string> ressult = request.Query.GetQueryData();
                ressult = ressult ?? new Dictionary<string, string>();
                return JsonSerializerUtility.EscSerialize(ressult);
            }
            else if (request.Method.Equals("post", StringComparison.OrdinalIgnoreCase))
            {
                return await request.GetPostData();
            }
            else
            {
                throw new Exception();// ResponseException(ResponseStatus.NotSupportMethod);
            }
        }
        internal static Dictionary<string, string> GetQueryData(this IQueryCollection query)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            if (query == null)
            {
                return result;
            }
            foreach (string key in query.Keys)
            {
                result.Add(key, query[key]);
            }
            return result;
        }
        internal static async Task<string> GetPostData(this HttpRequest request)
        {
            if (request.ContentType != null && request.ContentType.IndexOf("application/json", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return await request.GetKeyFromPostRequest();
            }
            else if (request.ContentType != null && request.ContentType.IndexOf("application/xml", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return await request.GetKeyFromPostRequest();
            }
            else if (request.ContentType != null && request.ContentType.IndexOf("text/xml", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return await request.GetKeyFromPostRequest();
            }
            else
            {

                if (!request.HasFormContentType)
                {
                    return await request.GetKeyFromPostRequest();
                }
                return request.Form.GetPostData();
            }
        }
        static async Task<string> GetKeyFromPostRequest(this HttpRequest request)
        {
            request.EnableBuffering();
            request.Body.Seek(0, SeekOrigin.Begin);
            string body = await new StreamReader(request.Body).ReadToEndAsync();
            request.Body.Seek(0, SeekOrigin.Begin);
            return body;
        }
        static string GetPostData(this IFormCollection form)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            if (form != null)
            {
                foreach (string key in form.Keys)
                {
                    result.Add(key, form[key]);
                }
            }
            return JsonSerializerUtility.EscSerialize(result);
        }
    }
}
