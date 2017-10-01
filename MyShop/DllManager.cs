using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;


namespace MyShop
{
    class DllManager
    {
        static List<string> dllsNames = new List<string>();

        public void ShowAllAvaliableDlls()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("ShowAllAvaliableDlls()");
            Console.ForegroundColor = ConsoleColor.White;

            string path = @"C:\Users\adm1n\Documents\Visual Studio 2017\Projects\MyShop\MyShop";
            
            string[] filesPathes = Directory.GetFiles(path);

            List<string> dllsPathes = new List<string>();
            
            for (int i = 0; i < filesPathes.Length; ++i)
            {
                if (filesPathes[i].EndsWith(".dll"))
                    dllsPathes.Add(filesPathes[i]);
                //File.Delete(fileEntries[i]);
            }

            dllsPathes.ForEach(Trim);

            void Trim(string s)
            {
                string stbuffer = "C:\\Users\\adm1n\\Documents\\Visual Studio 2017\\Projects\\MyShop\\MyShop";
                s = s.TrimEnd(new char[] { '.', 'd', 'l', 'l' });
                s = s.TrimStart(stbuffer.ToCharArray());
                dllsNames.Add(s);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("List of aavaliable dlls: ");
            foreach (string i in dllsNames)
                Console.WriteLine(i);
            Console.ForegroundColor = ConsoleColor.White;

        }

        public void LoadDlls()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("LoadDlls()");
            Console.ForegroundColor = ConsoleColor.White;

            void LoadDll(string name)
            {
                Assembly a1 = Assembly.Load(name);
                if (a1 != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Assembly.Load(namesOfDll[1]); - DONE");
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Dll" + name + "was not loaded.");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Object o = a1.CreateInstance(name);
                Type t = a1.GetType(name);
                MethodInfo mi = t.GetMethod("GetName");
                Console.WriteLine(mi.Invoke(o, null));
            }
            dllsNames.ForEach(LoadDll);
        }
    }
}
