using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
//using Food;

namespace MyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            //Assembly assembly = Assembly.Load("Flower");


            //Object o = assembly.CreateInstance("Flower");

            //Type t = assembly.GetType("Flower");

            //if (t == null)
            //    Console.WriteLine("NULL");




            //Console.WriteLine(Food.Food.Foo());

            LoadLibrarys loader = new LoadLibrarys();

            string path = @"C:\Users\adm1n\Documents\Visual Studio 2017\Projects\MyShop\MyShop";
            int numberOfProductsTypes = 0;

            List<string> namesOfDll = loader.GetDlls(path, ref numberOfProductsTypes);

            Console.WriteLine("-", 20);
            foreach (string i in namesOfDll)
                Console.WriteLine(i);


            //-----------------------------------------
            // to add dll

            string st0 = namesOfDll[0];
            string TrimedBack = st0.TrimEnd(new char[] { '.', 'd', 'l', 'l' });

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(TrimedBack);
            Console.ForegroundColor = ConsoleColor.White;

            string stbuffer = "C:\\Users\\adm1n\\Documents\\Visual Studio 2017\\Projects\\MyShop\\MyShop";
            //int x = stbuffer.Length;

             
            

            string TrimedFront = TrimedBack.TrimStart(stbuffer.ToCharArray());

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(TrimedFront);
            Console.ForegroundColor = ConsoleColor.White;



            Assembly a1 = Assembly.Load(TrimedFront);
            Console.WriteLine("Assembly.Load(namesOfDll[1]); - DONE");

            Object o = a1.CreateInstance("vscode");
            Type t = a1.GetType("vscode");

            MethodInfo mi = t.GetMethod("GetName");
            Console.WriteLine(mi.Invoke(o, null));






            //MethodInfo mi = t.GetMethod("Foo");

                //mi.Invoke(o,null);

                //Console.WriteLine("-", 20);





            Console.ForegroundColor = ConsoleColor.White;
            //TODO: add dlls to project and count products
            // add data base

            Base productsBase = new Base();
            Menu menu = new Menu();


            productsBase.InitBase();

            Console.ForegroundColor = ConsoleColor.Blue;

            int choice = -1;


            while (choice != 0)
            {

                menu.InviteUser();
                choice = Convert.ToInt32(Console.ReadLine());


                switch (choice)
                {
                    case 1:
                        productsBase.ShowBase();
                        break;
                    case 2:
                        productsBase.SortByPrice();
                        break;
                    case 3:
                        productsBase.SaveChanges();
                        break;

                    default:
                        Console.WriteLine("exit");
                        break;
                }
            }



        }
    }
}
