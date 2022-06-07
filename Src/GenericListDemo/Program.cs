using GenericListDemo.model;
using System;

namespace GenericListDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            USA usa = new USA()
            {
                Name = "科比",
                Age = 40
            };
            Chinese chinese = new Chinese()
            {
                Name = "xinxin",
                Age = 40
            };

            //ResponseData.Show<USA>(usa);
            ResponseData.Show<Chinese>(chinese);


        }
    }
}
