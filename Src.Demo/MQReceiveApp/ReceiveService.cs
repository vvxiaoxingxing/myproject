using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQReceiveApp
{
    public class ReceiveService
    {
        public void ReceiveMsg()
        {
            //IConnectionFactory connFactory = new ConnectionFactory//创建连接工厂对象
            //{
            //    HostName = "124.222.193.118",//IP地址
            //    Port = 5672,//端口号
            //    UserName = "xinxin",//用户账号
            //    Password = "xin123456",//用户密码
            //    VirtualHost = "/"
            //};

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
                new AmqpTcpEndpoint(){
                HostName = "124.222.193.118",//IP地址
                Port = 5672//端口号
            },
            new AmqpTcpEndpoint(){
                HostName = "103.38.252.85",//IP地址
                Port = 5672//端口号
            },             };
            using (IConnection conn = conFactory.CreateConnection(endpoints))
            {
                using (IModel channel = conn.CreateModel())
                {
                    string queueName = "diy_queue_fx";
                    //声明一个队列
                    channel.QueueDeclare(
                      queue: queueName,//消息队列名称
                      durable: false,//是否缓存
                      exclusive: false,
                      autoDelete: false,
                      arguments: null
                       );
                    //创建消费者对象
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        byte[] message = ea.Body.ToArray();//接收到的消息
                        Console.WriteLine("接收到信息为:" + Encoding.UTF8.GetString(message));
                    };
                    //消费者开启监听
                    channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
                    Console.ReadKey();
                }
            }
        }
    }
}
