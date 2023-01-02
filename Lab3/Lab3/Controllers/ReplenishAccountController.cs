using Lab3.Exeptions;
using Lab3.Model;

namespace Lab3.Controllers
{
    internal class ReplenishAccountController : ControllerInterface
    {
        private Account Account;
        public ReplenishAccountController(Account account) { Account = account; }
        public string Message() { return "Replenish the balance"; }
        public void Action()
        {
            Console.WriteLine("Enter the top-up amount: ");
            double balance = double.Parse(Console.ReadLine());
            if (balance > 0)
            {
                Account.Balance += balance;
            }
            else throw new NegativeBalanceException();
        }
    }
}
