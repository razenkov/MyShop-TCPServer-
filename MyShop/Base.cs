using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyShop
{
    class Base
    {
        public Flower[] flowers = null;
        public int numberOfProducts = 100;

        public void InitBase()
        {
            string[] names = { "rose", "pion", "lily", "camomile" };
            string[] colors = { "red", "blue", "green" };

            Console.WriteLine("type a number of products you want to init: ");

            numberOfProducts = Convert.ToInt32(Console.ReadLine());

            flowers = new Flower[numberOfProducts];

            Random rnd = new Random();

            for (int i = 0; i < numberOfProducts; ++i)
            {
                flowers[i] = new Flower(names[rnd.Next(0, 4)], rnd.NextDouble() * 10, rnd.Next(1, 1000), colors[rnd.Next(0, 3)]);
            }
        }

        public void ShowBase()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            for (int i = 0; i < numberOfProducts; ++i)
            {
                Console.WriteLine("Name: {0}, price: {1}, amount: {2}, color: {3}", flowers[i].mName, flowers[i].mPrice, flowers[i].mAmount, flowers[i].mColor);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void SaveChanges()
        {
            StreamWriter sw = new StreamWriter(@"C:\Users\adm1n\Documents\Visual Studio 2017\Projects\MyShop\ProductsBase.txt");

            for (int i = 0; i < this.numberOfProducts; ++i)
            {
                sw.WriteLine(this.flowers[i].mName + ' ' + this.flowers[i].mPrice + ' ' + this.flowers[i].mAmount + ' ' + this.flowers[i].mColor);
            }
            sw.Close();
            Console.WriteLine("Changes saved.");
        }

        public void SortByPrice()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("SortByPrice()");

            for (int i = 0; i < this.numberOfProducts; i++)
            {
                for (int j = 0; j < flowers.Length - 1; j++)
                {
                    if (flowers[j].mPrice > flowers[j + 1].mPrice)
                    {
                        double temp = flowers[j + 1].mPrice;
                        flowers[j + 1].mPrice = flowers[j].mPrice;
                        flowers[j].mPrice = temp;
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
