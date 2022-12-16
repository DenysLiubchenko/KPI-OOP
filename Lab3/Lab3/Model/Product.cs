using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Model
{
    internal class Product
    {
        public uint ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Product(string Name, double Price)
        {
            this.Name = Name;
            this.Price = Price;
        }
    }
}
