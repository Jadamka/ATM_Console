using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Console
{
    public class User
    {
        public long CardNumber { get; set; } // 16 digits
        public int Pin { get; set; } // 4 digits
        public string Name { get; set; }
        public int Money { get; set; }

        public User(int CN, int Pin, string Name, int Money)
        {
            this.CardNumber = CN;
            this.Pin = Pin;
            this.Name = Name;
            this.Money = Money;
        }
    }
}
