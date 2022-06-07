
using GenericListDemo.impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericListDemo.model
{
    /// <summary>
    /// 安徽人
    /// </summary>
    public class AH:Chinese,IWork
    {
        public string ChaoHu { get; set; }


        public void Chaohu<T>() where T : AH
        {
            Console.WriteLine("安徽有巢湖。");

        }

        public void DoWork()
        {
            Console.WriteLine("安徽人民在工作。");
        }
    }
}
