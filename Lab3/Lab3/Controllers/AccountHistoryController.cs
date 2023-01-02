using Lab3.Model;

namespace Lab3.Controllers
{
    internal class AccountHistoryController : ControllerInterface
    {
        private DataBase Data;
        private Account Account;
        public AccountHistoryController(DataBase data, Account account) { Data = data; Account = account; }
        public string Message() { return "Account History"; }
        public void Action()
        {
            foreach(History history in Data.GetHistoryOfAccount(Account.ID))
            {
                Console.WriteLine(history.Account.Name + " - " + history.Product.Name + " for " + history.Product.Price+"$");
            }
        }
    }
}
