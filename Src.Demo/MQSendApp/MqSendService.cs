using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQSendApp
{
    public class MqSendService
    {
        public void SendMsg()
        {
            IConnectionFactory conFactory = new ConnectionFactory//创建连接工厂对象
            {
                //HostName = "124.222.193.118",//IP地址
                //Port = 5672,//端口号
                UserName = "xinxin",//用户账号
                Password = "xin123456",//用户密码
                //HostName = "124.222.193.118",//IP地址
                //Port = 5672,//端口号
                //UserName = "xinxin",//用户账号
                //Password = "1qazQAZ2wsxWSX",//用户密码
            };
            List<AmqpTcpEndpoint> endpoints = new List<AmqpTcpEndpoint>()
            {
                new AmqpTcpEndpoint()
                {
                    HostName = "103.38.252.85",//IP地址
                    Port = 5672//端口号
                },
                new AmqpTcpEndpoint()
                {
                    HostName = "124.222.193.118",//IP地址
                    Port = 5672//端口号
                }
            };
            using (IConnection con = conFactory.CreateConnection(endpoints))//创建连接对象
            {
                using (IModel channel = con.CreateModel())//创建连接会话对象
                {
                    string queueName = "diy_queue_fx";
                    //if (args.Length > 0)
                    //    queueName = args[0];
                    //else
                    //    queueName = "queue1";
                    //声明一个队列
                    channel.QueueDeclare(
                      queue: queueName,//消息队列名称
                      durable: false,//是否缓存
                      exclusive: false,
                      autoDelete: false,
                      arguments: null
                       );
                    while (true)
                    {
                        Console.WriteLine("消息内容:");
                        String message = Console.ReadLine();
                        //消息内容
                        byte[] body = Encoding.UTF8.GetBytes(message);
                        //发送消息
                        channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
                        Console.WriteLine("成功发送消息:" + message);
                    }
                }
            }
        }
    }
}
