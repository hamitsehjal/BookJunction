using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Hamit
{
   public class User
    {
        public string Name { get; set; }
        public User(string name)
            {
               Name = name;
            }
    }
}
