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
            string path = @"C:\Users\adm1n\Documents\Visual Studio 2017\Projects\MyShop\MyShop";
            
            string[] filesPathes = Directory.GetFiles(path);

            List<string> dllsPathes = new List<string>();
            //List<string> dllsNames = new List<string>();

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
            
            //Assembly a1 = Assembly.Load(TrimedFront);
            Console.WriteLine("Assembly.Load(namesOfDll[1]); - DONE");

            //Object o = a1.CreateInstance("vscode");
            //Type t = a1.GetType("vscode");

            //MethodInfo mi = t.GetMethod("GetName");
            //Console.WriteLine(mi.Invoke(o, null));
        }
    }
}
