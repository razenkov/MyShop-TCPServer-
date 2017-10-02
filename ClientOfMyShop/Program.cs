using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace ClientOfMyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            if (false)
            {
                //string CurrentUserID = new ID().RestoreUserID();
            }
           

            Console.WriteLine("Client Starts;");
            Socket ClientSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("192.168.0.103"), 1080);

            ClientSocket.Connect(endPoint);

            while (true)

            {
                Console.WriteLine("Enter msg: ");

                string msg = Console.ReadLine();

                byte[] msgBuffer = Encoding.Default.GetBytes(msg);

                ClientSocket.Send(msgBuffer, 0, msgBuffer.Length, 0);

                byte[] buffer = new byte[255];

                int recive = ClientSocket.Receive(buffer, 0, buffer.Length, 0);

                Array.Resize(ref buffer, recive);

                Console.WriteLine("Resived: {0}", Encoding.Default.GetString(buffer));


            }

            ClientSocket.Close();//TODO: Find good way to close socket
        }
    }
}
