using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace TCPServer
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            //TcpListener serverSocket = new TcpListener(6789);
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener serverSocket = new TcpListener(ip, 6789);

            Console.WriteLine("Server started and then the main thread is blocked");
            serverSocket.Start();


            TcpClient connectionSocket = serverSocket.AcceptTcpClient();
            Console.WriteLine("Server activated");
            //NetworkStream ns = new NetworkStream(connectionSocket);
            //only on real sockets not TcpClient
            Stream ns = connectionSocket.GetStream();

            //StreamReader læser karather fra en byte stream
            StreamReader sr = new StreamReader(ns);
            //StreamWriter skriv karather til en stream
            StreamWriter sw = new StreamWriter(ns);
            //Gets or sets a value indicating whether the StreamWriter will flush its buffer to the underlying stream after every call to StreamWriter.Write
            sw.AutoFlush = true;

            while (true)
            {
                string message = sr.ReadLine();
                Console.WriteLine("Client: " + message);
                if (message == "STOP") break;
                string answer = Console.ReadLine();
                sw.WriteLine(answer);
            }

            Console.WriteLine("Server stopped, press ENTER");
            string s = Console.ReadLine();

            ns.Close();
            connectionSocket.Close();
            serverSocket.Stop();
        }
    }
}
