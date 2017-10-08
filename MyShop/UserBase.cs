using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyShop
{
    public class UserBase
    {
         User[] Customers;
        public int numberOfCustomers;

        public void Start()
        {
            Console.WriteLine("Start of UserBase....");
            this.InitUserBase();
            this.ShowUsers();
            this.SaveUsers();


            this.RestoreCustomers();
        }

        public void NewBase(int num)
        {
            numberOfCustomers = num;

            Customers = new User[num];
            for (int i = 0; i < numberOfCustomers; ++i)
            {
                Customers[i] = new User();
            }
        }
        
        public void InitUserBase()
        {
            Console.WriteLine("---InitUserBase()");

            try
            {
                StreamReader sr = new StreamReader(@"C:\Users\adm1n\Documents\Visual Studio 2017\Projects\MyShop\UsersBase.txt");

                int count = 0;
                Console.WriteLine("Start to restore ecisting Base of Users.");

                while (sr.ReadLine() != null)
                {
                    count++;
                }

                numberOfCustomers = count;

                Customers = new User[count];

                for (int i = 0; i < numberOfCustomers; ++i)
                {
                    Customers[i] = new User();
                    Customers[i].ShowUser();
                }
                sr.Close();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Customers restored successfully.");
                Console.ForegroundColor = ConsoleColor.White;

            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("FileNotFoundExceptions are handled here.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("New Base Init");
                this.NewBase(11);
            }
        }

        public void ShowUsers()
        {
            Console.WriteLine("---ShowUsers()");
            for (int i = 0; i < numberOfCustomers; ++i)
            {
                Console.WriteLine(Customers[i].Name + '*' + Customers[i].Soname + '*' + Customers[i].Age + '*' + Customers[i].Account + '*' +
                    Customers[i].Id);
            }
        }

        public void SaveUsers()
        {
            Console.WriteLine("---SaveUsers()");
            StreamWriter sw = new StreamWriter(@"C:\Users\adm1n\Documents\Visual Studio 2017\Projects\MyShop\UsersBase.txt");
            for (int i = 0; i < numberOfCustomers; ++i)
            {
                sw.WriteLine(Customers[i].Name + '*' + Customers[i].Soname + '*' + Customers[i].Age + '*' + Customers[i].Account + '*' +
                    Customers[i].Id);
                sw.Flush();
            }

            sw.Close();
            Console.WriteLine("Changes saved to userbase.");
        }

        public void RestoreCustomers()
        {
            Console.WriteLine("---RestoreCustomers()");




            //----------------------------------------------
            try
            {
                StreamReader sr = new StreamReader(@"C:\Users\adm1n\Documents\Visual Studio 2017\Projects\MyShop\UsersBase.txt");

                int count = 0;
                Console.WriteLine("Start to restore ecisting Base of Users.");

                while (sr.ReadLine() != null)
                {
                    count++;
                }

                numberOfCustomers = count;

                Customers = new User[count];

                for (int i = 0; i < numberOfCustomers; ++i)
                {
                    Customers[i] = new User();
                    Customers[i].ShowUser();
                }

                for (int i = 0; i < count; ++i)
                {
                    //char[] buff = new char[20];
                    string str1 = sr.ReadLine().ToString();
                    Console.WriteLine(str1);
                }

                Console.WriteLine("All users are restored.");
                sr.Close();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Customers restored successfully.");
                Console.ForegroundColor = ConsoleColor.White;

            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("FileNotFoundExceptions are handled here.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("New Base Init");
                this.NewBase(5);
            }
        }
        
        public void BinarySave()
        {
            Console.WriteLine(" BinarySave()");
            string path = @"C:\Users\adm1n\Documents\Visual Studio 2017\Projects\MyShop\BinaryUsersBase.txt";
            BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate));

            for(int i = 0; i < Customers.Length; ++i)
            {
                bw.Write(Customers[i].Name);
                bw.Write(Customers[i].Soname);
                bw.Write(Customers[i].Age);
                bw.Write(Customers[i].Account);
                bw.Write(Customers[i].Id);
            }

            bw.Close();
        }

        public void BinaryRestore()
        {
            Console.WriteLine("BinaryRead()");
            string path = @"C:\Users\adm1n\Documents\Visual Studio 2017\Projects\MyShop\BinaryUsersBase.txt";
            BinaryReader br = new BinaryReader(File.Open(path, FileMode.OpenOrCreate));

            for(int i = 0; i < Customers.Length; ++i)
            {
                Customers[i].Name = br.ReadString();
                Customers[i].Soname = br.ReadString();
                Customers[i].Age = br.ReadInt32();
                Customers[i].Account = br.ReadDouble();
                Customers[i].Id = br.ReadString();
            }
         
            br.Close();
        }

        public void AddNewUser(User user)
        {
            User[] newBase = new User[numberOfCustomers + 1];
            
            for(int i = 0; i < numberOfCustomers; ++i)
            {
                newBase[i] = Customers[i];
            }

            newBase[numberOfCustomers] = user;
            numberOfCustomers += 1;
            Customers = newBase;
        }

        




    } 

       
    
}
