using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyShop
{
    class UserBase
    {
        public static List<User> userBase;

        public UserBase()
        {
            userBase = new List<User>();

        }

        public void InitUserBase(int num)
        {
            List<User> tempUserBase = new List<User>();

            for (int i = 0; i < num; ++i)
            {
                userBase.Add(new User());
            }
        }

        public void ShowUsers()
        {
            userBase.ForEach(ShowUser);
        }

        public void Restore()
        {
            Console.WriteLine("Restore User Base");
        }

        public void ShowUser(User user)
        {
            Console.WriteLine(user.Name + ' ' + user.Soname + ' ' + user.Id);
        }

        public void SaveUsers()
        {
            StreamWriter sw = new StreamWriter(@"C:\Users\adm1n\Documents\Visual Studio 2017\Projects\MyShop\UsersBase.txt");
                userBase.ForEach(sw.WriteLine);
            
            sw.Close();
            Console.WriteLine("Changes saved to userbase.");
        }

        public void RestoreUsers()
        {
            Console.WriteLine("RestoreUsers()");
        }
    }
}
