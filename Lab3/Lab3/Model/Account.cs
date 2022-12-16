using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Model
{
    internal class Account
    {
        public uint ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }
        public Account(string name, string password)
        {
            Name = name;
            Password = password;
            Balance = 0;
        }
    }
}
