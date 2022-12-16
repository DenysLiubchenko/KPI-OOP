using Lab3.Exeptions;
using Lab3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Controllers
{
    internal class ReplenishAccountController : ControllerInterface
    {
        private Account Account;
        public ReplenishAccountController(Account account) { Account = account; }
        public string Message() { return "Replenish the balance"; }
        public void Action()
        {
            Boolean actionSucssesful = false;
            while (!actionSucssesful) 
            {
                Console.WriteLine("Enter the top-up amount: ");
                double balance = double.Parse(Console.ReadLine());
                if (balance > 0)
                {
                    actionSucssesful = true;
                    Account.Balance += balance;
                }
                else throw new NegativeBalanceException();
            }
            
        }
    }
}
