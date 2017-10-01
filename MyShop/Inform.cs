using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyShop
{
    class Menu
    {
        public void InviteUser()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Welcome to Shop, please chose what to do:");
            Console.WriteLine("to show all products press 1");
            Console.WriteLine("to sort product press       2");
            Console.WriteLine("to save all products press 3");
            //Console.WriteLine("to delete product press    4");
            Console.ForegroundColor = ConsoleColor.White;

        }

    }

    

}
