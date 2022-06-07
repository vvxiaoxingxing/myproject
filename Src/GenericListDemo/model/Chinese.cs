using System;
using System.Collections.Generic;
using System.Text;

namespace GenericListDemo.model
{
    /// <summary>
    /// 中国人
    /// </summary>
    public class Chinese:People
    {
        public string Yewllo { get; set; }

        public new void SayHi()
        {
            Console.WriteLine("我是中国人。");
        }
    }
}
