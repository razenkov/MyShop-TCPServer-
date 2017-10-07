using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyShop
{
    class ProductBase
    {
        public static Product[] mBaseOfProduct;
        public static int numberOfProducts;

        public void Start()
        {

        }

        public void NewBase(int num)
        {
            mBaseOfProduct = new Product[num];

            numberOfProducts = num;
            for(int i = 0; i < numberOfProducts; ++i)
            {
                mBaseOfProduct[i] = new Product();
            }
        }

        public void InitBaseOfProducts()
        {
            Console.WriteLine("InitBaseOfProducts");

            try
            {
                StreamReader sr = new StreamReader(@"C:\Users\adm1n\Documents\Visual Studio 2017\Projects\MyShop\BinaryProductsBase.txt");

                int count = 0;
                Console.WriteLine("Start to restore ecisting Base of Products.");

                while (sr.ReadLine() != null)
                {
                    count++;
                }

                numberOfProducts = count;

                mBaseOfProduct = new Product[count];

                for (int i = 0; i < numberOfProducts; ++i)
                {
                    mBaseOfProduct[i] = new Product();
                    mBaseOfProduct[i].ShowProduct();
                }
                sr.Close();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Products restored successfully.");
                Console.ForegroundColor = ConsoleColor.White;

            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("FileNotFoundExceptions are handled here.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("New Base 25 Init");
                this.NewBase(25);
            }
        }

        public void ShowProducts()
        {
            Console.WriteLine("ShowProducts");
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < numberOfProducts; ++i)
            {
                Console.WriteLine(mBaseOfProduct[i].GetHashCode() + " - hash");
                mBaseOfProduct[i].ShowProduct();
            }
            Console.ForegroundColor = ConsoleColor.White;

        }

        public void BinarySaveProducts()
        {
            Console.WriteLine("BinarySaveProducts");
            string path = @"C:\Users\adm1n\Documents\Visual Studio 2017\Projects\MyShop\BinaryProductsBase.txt";
            BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate));

            for (int i = 0; i < numberOfProducts; ++i)
            {
                mBaseOfProduct[i].SaveProduct(bw);
            }

            bw.Close();
        }

        public void BinaryRestoreProducts()
        {
            Console.WriteLine("BinaryRestoreProducts");
            string path = @"C:\Users\adm1n\Documents\Visual Studio 2017\Projects\MyShop\BinaryProductsBase.txt";
            BinaryReader br = new BinaryReader(File.Open(path, FileMode.OpenOrCreate));

            for (int i = 0; i < numberOfProducts; ++i)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("iteration - " + i);
                mBaseOfProduct[i].RestoreProduct(ref br, ref mBaseOfProduct[i]);
                Console.ForegroundColor = ConsoleColor.White;

            }

            br.Close();
        }

    }
}
