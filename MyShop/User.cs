﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyShop
{
    class User
    {
        public string Name;
        public string Soname;
        public int Age;
        double Account;
        public int Hash;
        public string Id;

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

            this.Id = Guid.NewGuid().ToString();
            Console.WriteLine("new user ID = " + this.Id);
        }

        public User()
        {
            Random r = new Random();
            this.Name = "default_name";
            this.Soname = "default_soname";
            this.Age = r.Next(1, 99);
            this.Account = 99.99;
            this.Id = Guid.NewGuid().ToString();
            //Console.WriteLine("new user ID = " + this.ID);

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
}