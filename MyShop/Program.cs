using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            new DllManager().ShowAllAvaliableDlls();
           

            //LoadLibrarys loader = new LoadLibrarys();

            //string path = @"C:\Users\adm1n\Documents\Visual Studio 2017\Projects\MyShop\MyShop";
            //int numberOfProductsTypes = 0;

            //List<string> namesOfDll = loader.GetDlls(path, ref numberOfProductsTypes);

            //Console.WriteLine("-", 20);
            //foreach (string i in namesOfDll)
            //    Console.WriteLine(i);


            //string st0 = namesOfDll[0];
            //string TrimedBack = st0.TrimEnd(new char[] { '.', 'd', 'l', 'l' });

            //Console.ForegroundColor = ConsoleColor.Magenta;
            //Console.WriteLine(TrimedBack);
            //Console.ForegroundColor = ConsoleColor.White;

            //string stbuffer = "C:\\Users\\adm1n\\Documents\\Visual Studio 2017\\Projects\\MyShop\\MyShop";
          
            //string TrimedFront = TrimedBack.TrimStart(stbuffer.ToCharArray());

            //Console.ForegroundColor = ConsoleColor.Magenta;
            //Console.WriteLine(TrimedFront);
            //Console.ForegroundColor = ConsoleColor.White;



            //Assembly a1 = Assembly.Load(TrimedFront);
            //Console.WriteLine("Assembly.Load(namesOfDll[1]); - DONE");

            //Object o = a1.CreateInstance("vscode");
            //Type t = a1.GetType("vscode");

            //MethodInfo mi = t.GetMethod("GetName");
            //Console.WriteLine(mi.Invoke(o, null));




            


            



        }
    }
}
