using System;

namespace MQReceiveApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new ReceiveService().ReceiveMsg();
        }
    }
}
