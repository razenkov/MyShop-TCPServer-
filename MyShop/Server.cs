using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
using System.Reflection;
using UserNamespace;



namespace MyShop
{
    class Server
    {
        
       
        





        public void StartUp(ref UserBase uBase, ref ProductBase pBase)
        {
            Console.WriteLine("Server waiting for connection....");
            Socket listener = new Socket(SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(0, 1080));


            while (true)
            {
                listener.Listen(0);

                Socket client = listener.Accept();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("New connection accepted.");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(client.GetHashCode());
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();


                var childSocketThread = new Thread(() =>
                {
                    byte[] buffer = new byte[1024];
                    int recive = client.Receive(buffer, 0, buffer.Length, 0);
                    Array.Resize(ref buffer, recive);


                    Console.WriteLine("=======================================================================================");
                    User u1 = new User();

                    u1 = (User)DeserializeObj(buffer);

                    Console.WriteLine(u1.Id);
                    Console.WriteLine("=======================================================================================");

                    Console.Read();

                    Console.Read();

                    while (true)
                    {
                        

                        
                        Console.WriteLine("Recieved data from client " + client.GetHashCode() + ": ");

                        while (true)

                        {
                            Console.WriteLine("Enter msg to client: ");

                            string msg = Console.ReadLine();

                            byte[] msgBuffer = Encoding.Default.GetBytes(msg);

                            client.Send(msgBuffer, 0, msgBuffer.Length, 0);

                            //byte[] buffer = new byte[255];

                            //int recive = client.Receive(buffer, 0, buffer.Length, 0);

                            Array.Resize(ref buffer, recive);

                            Console.WriteLine("Resived from client: {0}", Encoding.Default.GetString(buffer));


                        }


                        //for (int i = 0; i < size; i++)
                        //  Console.Write(Convert.ToChar(data[i]));

                        Console.WriteLine("SEFORE SWITCH");

                   

                        //switch (choice)
                        //{
                        //    case 0:
                        //        //exit
                        //        client.Close();
                        //        break;
                        //    case 1:
                        //        //Menu
                        //        SendMenu(client);
                        //        break;
                        //    case 2:
                        //       //ShowProducts
                        //        break;
                        //    case 3:
                        //        //choose product
                        //        break;
                        //    case 4:
                        //        //to buy
                        //        break;
                        //    case 5:
                        //        //to cansel
                        //        break;
                        //    case 6:
                        //        //RegistrateNewUser(uBase, client);
                        //    //if you are new customer please press 6
                        //    // RegistrateNewUser(client);
                        //        break;
                        //    default:
                        //        break;
                        //}                                         
                    }                    
                });

                childSocketThread.Start();
            }
        }

        public void SendMenu(Socket client)
        {
            byte[] menuMsg = Encoding.Default.GetBytes
                (
                    "Welcome to Shop, please chose what to do:\n" +
                    " to exit press 0\n" +
                    " to go to MENU press 1\n" +
                    " to show product press       2\n" +
                    " to save all products press 3\n" +
                    " to delete product press    4\n"
                );
            client.Send(menuMsg);
        }

        public void RegistrateNewUser(Socket client)
        {
            byte[] name = new byte[1024];
            client.Send(Encoding.Default.GetBytes("Please enter your name"));
            client.Receive(name);
            Convert.ToChar(name);

            byte[] soname = new byte[1024];
            client.Send(Encoding.Default.GetBytes("Please enter your soname"));
            client.Receive(soname);
            Convert.ToChar(soname);

            byte[] age = new byte[1024];
            client.Send(Encoding.Default.GetBytes("Please enter your soname"));
            client.Receive(soname);
            

            string n = name.ToString();
            string s = soname.ToString();
            int a = Convert.ToInt32(age);

            User user = new User(n, s, a, 0);

            //user.Hash = user.GetHashCode();
            //uBase.AddNewUser(ref user);
        }


        //serialize
        public static byte[] SerializeObj(object obj)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("serialize");
            using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                formatter.Serialize(stream, obj);

                byte[] bytes = stream.ToArray();
                stream.Flush();

                return bytes;
            }
            Console.ForegroundColor = ConsoleColor.White;

        }

        //deserialize
        public static object DeserializeObj(byte[] binaryObj)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("deserialize");
            using (System.IO.MemoryStream stream = new System.IO.MemoryStream(binaryObj))
            {
                stream.Position = 0;
                object desObj = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter().Deserialize(stream);
                return desObj;
            }
            Console.ForegroundColor = ConsoleColor.White;

        }





    }
}


