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

            //develop

            MyShop Shop = new MyShop();
            Shop.Start();

            UserBase Userbase = new UserBase();
            Userbase.Start();

            ProductBase Productbase = new ProductBase();
            Productbase.Start();

            //startup server
            Server server1 = new Server();
            server1.StartUp(ref Userbase, ref Productbase);
            
        }
    }
}
