using System;
using System.IO;
using System.Net.Sockets;

namespace EchoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client");

            TcpClient socket = new TcpClient("localhost", 7);

            NetworkStream ns = socket.GetStream();
            StreamReader reader = new StreamReader(ns);
            StreamWriter writer = new StreamWriter(ns);

            string message = null;
            while (message == null || !message.Equals("end", StringComparison.OrdinalIgnoreCase))
            {
                message = Console.ReadLine();

                writer.WriteLine(message);
                writer.Flush();

                string receivedMessage = reader.ReadLine();
                Console.WriteLine("Server sent: " + receivedMessage);
            }
            socket.Close();
        }
    }
}
