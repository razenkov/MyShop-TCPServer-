using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop
{
    class Flower : Product
    {
        public string mColor;

        public Flower(string name, double price, int amount, string color)
        {
            this.mColor = color;
            this.mAmount = amount;
            this.mName = name;
            this.mPrice = price;
        }

        public void ShowProduct()
        {
            Console.WriteLine("Name: {0}, price: {1}, amount: {2}, color: {3}", mName, mPrice, mAmount, mColor);
        }
    }
}
