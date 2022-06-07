using GenericListDemo.impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericListDemo.model
{
    /// <summary>
    /// 美国人
    /// </summary>
    public class USA:IWork
    {
        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 黑皮肤
        /// </summary>
        public string Black { get; set; }

        public void DoWork()
        {
            Console.WriteLine("美国佬zaigongzuo.");
        }

        public void SaiHi()
        {
            Console.WriteLine("美国佬好多黑人。");
        }
    }
}
