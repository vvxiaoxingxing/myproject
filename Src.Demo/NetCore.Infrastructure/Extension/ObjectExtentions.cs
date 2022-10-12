using NetCore.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NetCore.Infrastructure.Extension
{
    public static class ObjectExtentions
    {
        public static bool IsNullOrEmpty(this object obj)
        {
            if (obj == null)
                return true;
            else
            {
                string objStr = obj.ToString();
                return string.IsNullOrEmpty(objStr);
            }
        }
        public static int AsInt(this System.Enum enu)
        {
            return Convert.ToInt32(enu);
        }
        public static string AsStr(this Enum enu)
        {
            Type type = enu.GetType();
            string fieldName = enu.ToString();
            FieldInfo fieldInfo = type.GetField(fieldName);
            if (fieldInfo.IsDefined(typeof(EnumDescribeAttribute), true))
            {
                var attribute = fieldInfo.GetCustomAttribute<EnumDescribeAttribute>();
                string description = attribute.Label;
                return description;
            }
            return enu.ToString();
        }
        public static async Task ForeachAsync<T>(this IEnumerable<T> datas, Func<T, Task> action)
        {
            if (datas == null)
            {
                return;
            }
            foreach (var d in datas)
            {
                await action.Invoke(d);
            }
        }
        //public static List<T> ExtentionDistinct<T>(this List<T> sources, Func<T, T, bool> func) where T : class
        //{
        //    if (sources == null)
        //    {
        //        return null;
        //    }
        //    return sources.Distinct<T>(new ObjectEqualityComparer<T>(func)).ToList();
        //}
        public static async Task<T> TryHandler<S, T>(this Func<S, Task<T>> handler, S s, Action<Exception> exceptionHandler = null)
        {
            try
            {
                return await handler.Invoke(s);
            }
            catch (Exception ex)
            {
                if (exceptionHandler != null)
                {
                    exceptionHandler.Invoke(ex);
                }
                return default(T);
            }
        }
        public static async Task<T> TryHandler<S1, S2, T>(this Func<S1, S2, Task<T>> handler, S1 s1, S2 s2, Action<Exception> exceptionHandler = null)
        {
            try
            {
                return await handler.Invoke(s1, s2);
            }
            catch (Exception ex)
            {
                if (exceptionHandler != null)
                {
                    exceptionHandler.Invoke(ex);
                }
                return default(T);
            }
        }
        public static async Task<T> TryHandler<S1, S2, S3, S4, T>(this Func<S1, S2, S3, S4, Task<T>> handler, S1 s1, S2 s2, S3 s3, S4 s4, Action<Exception> exceptionHandler = null)
        {
            try
            {
                return await handler.Invoke(s1, s2, s3, s4);
            }
            catch (Exception ex)
            {
                if (exceptionHandler != null)
                {
                    exceptionHandler.Invoke(ex);
                }
                return default(T);
            }
        }

        public static string RemoveHtmlTag(this string html, int length = 0)
        {
            if (string.IsNullOrWhiteSpace(html))
            {
                return string.Empty;
            }
            html = html.HtmlEntity2Text();
            string strText = Regex.Replace(html, @"<[^>]+>", "");
            if (length > 0 && strText.Length > length)
                return strText.Substring(0, length);

            return strText;
        }

        public static string HtmlEntity2Text(this string str)
        {
            //将html实体编码转换到正常字符
            string regx = "(?<=(& #)).+?(?=;)";
            MatchCollection matchCol = Regex.Matches(str, regx);
            if (matchCol.Count > 0)
            {
                for (int i = 0; i < matchCol.Count; i++)
                {
                    int asciinum = int.Parse(matchCol[i].Value);
                    char c = (char)asciinum;
                    str = str.Replace(string.Format("& #{0};", asciinum), c.ToString());
                }
            }
            return str;
        }

    }
}
