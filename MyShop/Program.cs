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

            //---MyShop Shop = new MyShop();
            //---Shop.Start();

            //---UserBase Userbase = new UserBase();
            //---Userbase.Start();

            ProductBase Productbase = new ProductBase();
            Productbase.InitBaseOfProducts();
            Productbase.ShowProducts();

            Productbase.BinarySaveProducts();
            Productbase.ShowProducts();

            Productbase.BinaryRestoreProducts();
            Productbase.ShowProducts();





            //restore data_base

            //restore users_base
            //new UserBase.Restore();

            //startup server
            //new Server().StartUp();
        }
    }
}
