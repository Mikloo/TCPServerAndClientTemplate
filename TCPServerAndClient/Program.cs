using System;
using System.IO;
using System.Net.Sockets;

namespace TCPServerAndClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //Provides client connections for TCP network services
            TcpClient clientSocket = new TcpClient("127.0.0.1", 6789);
            Console.WriteLine("Client ready");

            Stream ns = clientSocket.GetStream();  //provides a Stream

            //StreamReader læser karather fra en byte stream
            StreamReader sr = new StreamReader(ns);
            //StreamWriter skriv karather til en stream
            StreamWriter sw = new StreamWriter(ns);
            //Gets or sets a value indicating whether the StreamWriter will flush its buffer to the underlying stream after every call to StreamWriter.Write
            sw.AutoFlush = true; // enable automatic flushing

            string message = Console.ReadLine();
            sw.WriteLine(message);
            string serverAnswer = sr.ReadLine();

            Console.WriteLine("Server: " + serverAnswer);

            Console.WriteLine("No more from server. Press Enter");
            Console.ReadLine();

            ns.Close();

            clientSocket.Close();

        }
    }
}
