using CrawlerCore.DependencyInjection;
using CrawlerDemo.Service;
using CrawlerService;
using ICrawlerService;
using System;

namespace CrawlerDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //依赖注入
            //DependencyInjectionCore.Init();
            //LotteryService.GetArray3();





            //IArray3Service arrayService = new Array3Service();
            //arrayService.SaveArray3InfoAsync();
        }
    }
}
