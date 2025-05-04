using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Admin
    {
        public string Name { get; set; }
        public string PassWord {  get; set; }
        public Admin() { }
        public Admin(string name, string password)
        {
            Name = name;
            PassWord = password;
        }
    }
}
