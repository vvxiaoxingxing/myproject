using System;

namespace MQSendApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new MqSendService().SendMsg();
        }
    }
}
