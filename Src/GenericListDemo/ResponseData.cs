using GenericListDemo.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericListDemo
{
    /// <summary>
    /// 泛型：不同的参数类型都能传递进来，
    /// </summary>
    public class ResponseData
    {
        /// <summary>
        /// 泛型约束：where T : People
        /// T 必须是People或者是People的子类才能调用这个方法。
        /// 
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public static void Show<T>( T t) where T : People 
        {
            Console.WriteLine($"{t.Name}_{t.Age}");
        }
    }
}
