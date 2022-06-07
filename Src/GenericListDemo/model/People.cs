using System;
using System.Collections.Generic;
using System.Text;

namespace GenericListDemo.model
{
    public class People
    {
        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        public void SayHi()
        {
            Console.WriteLine("Hi~");
        }
    }
}
