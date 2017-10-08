using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ClientOfMyShop
{
    class Program
    {
        public static bool isNewUser = false;
        public static string Id;

        static void Main(string[] args)
        {

            User user = RegistrateNewUser();
            user.ShowUser();

            Console.WriteLine("===========================");
            Console.Read();

            if (isNewUser)
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

        public void BinarySaveId()
        {
            Console.WriteLine("BinarySaveId");
            string path = @"C:\Users\adm1n\Documents\Visual Studio 2017\Projects\MyShop\Id.txt";

            BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate));
            bw.Write(Id);
            bw.Close();
        }

        public void BinaryRestoreId()
        {
            Console.WriteLine("BinaryRestoreId");
            string path = @"C:\Users\adm1n\Documents\Visual Studio 2017\Projects\MyShop\Id.txt";

            BinaryReader br = new BinaryReader(File.Open(path, FileMode.OpenOrCreate));
            Id = br.ReadString();
            br.Close();
        }

        public static User RegistrateNewUser()
        {
            Console.WriteLine("You are new user, we need you to registrate. Please enter your name:");
            User newUser = new User();
            newUser.Name = Console.ReadLine();

            Console.WriteLine("Please enter your soname");
            newUser.Soname = Console.ReadLine();

            Console.WriteLine("Please enter your age");
            newUser.Age = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Please enter your sex");
            newUser.Sex = Console.ReadLine();

            return newUser;
        }

    }
}
