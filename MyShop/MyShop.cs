﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop
{
    class MyShop
    {
        public void Start()
        {
            new DllManager().ShowAllAvaliableDlls();
            //new DllManager().LoadDlls();
        }

        
    }
}
