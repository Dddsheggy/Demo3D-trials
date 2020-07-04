using System;
using NetMQ;
using NetMQ.Sockets;

namespace ServerTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("服务器开启中...");

            using (NetMQSocket serverSocket = new ResponseSocket())
            {
                serverSocket.Bind("tcp://127.0.0.1:5556"); //监听
                while (true)
                {
                    string message1 = serverSocket.ReceiveFrameString();
                    Console.WriteLine("接收到的消息 :\r\n{0}\r\n", message1);
                    //string[] msg = message1.Split(':');
                    //string message = msg[];
                    //region 根据接收到的消息，返回不同的信息
                    if (message1 == "Hello")
                    {
                        serverSocket.SendFrame("World\r\n");

                    }
                    else if (message1 == "ni hao")
                    {
                        serverSocket.SendFrame("Ni Hao\r\n");

                    }
                    else if (message1 == "hi")
                    {
                        serverSocket.SendFrame("Hi\r\n");
                    }
                    else
                    {
                        serverSocket.SendFrame(message1);
                    }
                    //endregion

                    if (message1 == "exit")
                    {
                        break;
                    }

                }
            }
        }
    }
}
