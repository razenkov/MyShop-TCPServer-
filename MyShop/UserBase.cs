using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyShop
{
    class UserBase
    {
        public static User[] Customers;

        public int numberOfCustomers;

        public void NewBase(int num)
        {
            Console.WriteLine("NewBase(int num)");
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

        public void ShowUsers()
        {
            Console.WriteLine("---ShowUsers()");
            for(int i = 0; i < numberOfCustomers; ++i)
            {
                Console.WriteLine(Customers[i].Name + Customers[i].Soname + Customers[i].Id);
            }
        }

        public void SaveUsers()
        {
            Console.WriteLine("---SaveUsers()");
            StreamWriter sw = new StreamWriter(@"C:\Users\adm1n\Documents\Visual Studio 2017\Projects\MyShop\UsersBase.txt");
            for(int i = 0; i < numberOfCustomers; ++i)
            {
                sw.WriteLine(Customers[i]);
                sw.Flush();
            }
            
            sw.Close();
            Console.WriteLine("Changes saved to userbase.");
        }

        public void RestoreCustomers()
        {
            Console.WriteLine("---SaveUsers()");
            StreamReader sr = new StreamReader(@"C:\Users\adm1n\Documents\Visual Studio 2017\Projects\MyShop\UsersBase.txt");

            
            for(int i = 0; i < numberOfCustomers; ++i)
            {
                //Customers[i] = sr.ReadLine();      
            }

            Console.WriteLine("All users are restored.");
        }

       
    }
}
