using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace SocketIterative
{
    class MainProgram
    {
        public static void Main(string[] args)
        {

            string name = "127.0.0.1";
            IPAddress ip = IPAddress.Parse(name);

            Console.WriteLine(ip);

            TcpListener serverSocket = new TcpListener(ip, 6789);

            //Depricated style
            //TcpListener serverSocket = new TcpListener(6789);


            serverSocket.Start();

            while (true)
            {
                TcpClient connectionSocket = serverSocket.AcceptTcpClient();
                //Socket connectionSocket = serverSocket.AcceptSocket();
                Console.WriteLine("Server activated");

                Stream ns = connectionSocket.GetStream();
                //Stream ns = new NetworkStream(connectionSocket);

                StreamReader sr = new StreamReader(ns);
                StreamWriter sw = new StreamWriter(ns);
                sw.AutoFlush = true; // enable automatic flushing

                string message = sr.ReadLine();
                string answer = "";
                while (message != null && message != "")
                {
                    Console.WriteLine("Client: " + message);
                    answer = message.ToUpper();
                    sw.WriteLine(answer);
                    message = sr.ReadLine();

                }
                connectionSocket.Close();
                ns.Close();
            }

            serverSocket.Stop();

        }
    }
}
