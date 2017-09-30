using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace MyShop
{
    class MyFile
    {

        public void Save(Base MyBase)
        {
            StreamWriter sw = new StreamWriter(@"C:\Users\adm1n\Documents\Visual Studio 2017\Projects\MyShop\ProductsBase.txt");

            for (int i = 0; i < MyBase.numberOfProducts; ++i)
            {
                sw.WriteLine(MyBase.flowers[i].mName + ' ' + MyBase.flowers[i].mPrice + ' ' + MyBase.flowers[i].mAmount + ' ' + MyBase.flowers[i].mColor);
            }
            sw.Close();        
            Console.WriteLine("Changes saved.");
        }


  

        public void Restore(Base MyBase)
        {
            StreamReader sr = new StreamReader(@"C:\Users\adm1n\Documents\Visual Studio 2017\Projects\MyShop\ProductsBase.txt");

            for (int i = 0; i < MyBase.numberOfProducts; ++i)
            {
                string line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            //sw.Close();



            //FileStream fstream = File.OpenRead(@"C:\SomeDir\noname\note.txt");

            //byte[] array = new byte[fstream.Length];

            //fstream.Read(array, 0, array.Length);

            //string textFromFile = System.Text.Encoding.Default.GetString(array);
            //Console.WriteLine("Текст из файла: {0}", textFromFile);


        }
    }
}   


