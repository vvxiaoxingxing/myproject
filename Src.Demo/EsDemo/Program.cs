using Elasticsearch.Net;
using Nest;
using System;

namespace EsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World ES!");

            var nodes = new Uri[]
            {
                new Uri("http://103.35.252.85:9200")
            };

            var pool = new StaticConnectionPool(nodes);
            var settings = new ConnectionSettings(pool);
            var client = new ElasticClient(settings);




        }
    }
}
