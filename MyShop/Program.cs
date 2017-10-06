using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;

            //develop

            //MyShop MainShop = new MyShop();
            //MainShop.Start();

            UserBase BaseOfUsers = new UserBase();
            BaseOfUsers.InitUserBase();
            BaseOfUsers.ShowUsers();
            BaseOfUsers.SaveUsers();


            BaseOfUsers.RestoreCustomers();

            BaseOfUsers.ShowUsers();


            //restore data_base

            //restore users_base
            //new UserBase.Restore();

            //startup server
            //new Server().StartUp();
        }
    }
}
