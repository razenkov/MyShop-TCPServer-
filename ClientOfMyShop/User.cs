using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyShop
{
    public class User
    {
        public string Name;
        public string Soname;
        public int Age;
        double Account;
        public int Hash;
        public string ID;

        Product[] AlreadyBuy;

        public User(string name, string soname, int age, double account)
        {
            this.Name = name;
            this.Soname = soname;
            this.Age = age;

            if (account != 0)
                this.Account = account;
            else
                this.Account = 100.0;

            this.ID = Guid.NewGuid().ToString();
            Console.WriteLine("new user ID = " + this.ID);
        }
    }

    public class ID
    {
        public void StoreUserID(string id)
        {
            StreamWriter sw = new StreamWriter(@"C:\Users\adm1n\Documents\Visual Studio 2017\Projects\MyShop\ClientOfMyShop\userID.txt");
            sw.WriteLine(id);
        }

        public string RestoreUserID()
        {
            StreamReader sr = new StreamReader(@"C:\Users\adm1n\Documents\Visual Studio 2017\Projects\MyShop\ClientOfMyShop\userID.txt");
            return sr.ReadLine();
        }
    }

}