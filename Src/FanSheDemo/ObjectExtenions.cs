using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FanSheDemo
{
    public static class ObjectExtenions
    {
        public static async Task<T> TryHandler<S, T>(this Func<S, Task<T>> handler, S s, Action<S, Exception> exceptionHandler = null)
        {
            try
            {
                return await handler.Invoke(s);
            }
            catch (Exception ex)
            {
                if (exceptionHandler != null)
                {
                    exceptionHandler.Invoke(s, ex);
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

        public static async Task<T> TryHandler<S1, S2, T>(this Func<S1, S2, Task<T>> handler, S1 s1, S2 s2, Action<S1,S2,Exception> exceptionHandler = null)
        {
            try
            {
                return await handler.Invoke(s1, s2);
            }
            catch (Exception ex)
            {
                if (exceptionHandler != null)
                {
                    exceptionHandler.Invoke(s1,s2,ex);
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


    }
}
