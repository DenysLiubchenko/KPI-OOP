using Lab3.Exeptions;
using Lab3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Controllers
{
    internal class BuyProductController : ControllerInterface
    {
        private DataBase Data;
        private Account Account;
        public BuyProductController(DataBase data, Account account) { Data = data; Account = account; }
        public string Message() { return "Select and Buy product"; }
        public void Action()
        {
            Console.WriteLine("Select Category: ");
            int categoryNum = int.Parse(Console.ReadLine());
            Console.WriteLine("Select Product: ");
            int productNum = int.Parse(Console.ReadLine());
            Product product = Data.Categories[Data.Categories.Keys.ElementAt(categoryNum)].ElementAt(productNum);
            if (product.Price > Account.Balance) { throw new NotEnoughMoneyException(); }
            else 
            {
                Account.Balance -= product.Price;
                Data.History.Add(new History(Account, product));
                Data.Categories[Data.Categories.Keys.ElementAt(categoryNum)].RemoveAt(productNum);
                Console.WriteLine("Product "+product.Name+" has been sucsessfuly purchased");
            }
        }
    }
}
