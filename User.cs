using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class User
    {
        public string Name { get; set; }
        public string PassWord { get; set; }
        public int id { get; private set; } 

        public string Email { get; set; }

        public List<Books> sachMuon { get; set; }
        public List<Books> yeuThich { get; set; }

        private static int nextId = 1;
        public User()
        {
            id = nextId; 
            nextId++;   
        }

        internal void ShowDialog()
        {
            throw new NotImplementedException();
        }
    }
    
}
