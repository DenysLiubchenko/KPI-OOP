using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Model;

namespace Lab3.Controllers
{
    internal class ShowProductsController : ControllerInterface
    {
        private DataBase Data;
        public ShowProductsController(DataBase data) { Data = data; }
        public string Message() { return "Show products"; }
        public void Action()
        {
            int i = 0;
            foreach(string category in Data.Categories.Keys){
                int j = 0;
                Console.WriteLine(i++ + " " + category);
                foreach(Product product in Data.Categories[category])
                {
                    Console.WriteLine("\t"+j++ + ") " + product.Name + " - " + product.Price + "$");
                }
            }
        }
    }
}
