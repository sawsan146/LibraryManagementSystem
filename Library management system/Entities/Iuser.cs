﻿using LibraryManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.Entities
{
    public  interface Iuser
    {
        public string Name { get; set; }
      
        public void DisplayBooks(Library lib);
       



    }
}
