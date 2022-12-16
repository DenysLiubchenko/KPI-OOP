using Lab3.Exeptions;
using Lab3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Controllers
{
    internal class ManageController
    {
        private Dictionary<string, List<ControllerInterface>> Controllers { get; set; }
        private Account User { get; set; }
        private DataBase Data { get; set; }
        public ManageController()
        {
            Data = new DataBase();
        }
        private void SignInUser()
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Account account = Data.FindAccountByName(name);
            if (account == null) throw new SignInException();
            Console.WriteLine("Enter your password: ");
            string password = Console.ReadLine();
            if (!password.Equals(account.Password)) throw new SignInException();
            User = account;
        }
        private void RegisterUser()
        {
            string name;
            Console.WriteLine("Enter your Name: ");
            name = Console.ReadLine();
            if (Data.FindAccountByName(name) != null) throw new RegisterException();
            Console.WriteLine("Enter your Password: ");
            string password = Console.ReadLine();
            if (password.Equals("") || name.Equals("")) throw new ArgumentNullException();
            User = Data.CreateAccount(name, password);
            Data.Accounts.Add(User);
        }
        private void Start() 
        {
            while (User == null)
            {
                Console.WriteLine("0) Sign in Account\n1) Registration");
                try
                {
                    switch (Console.ReadLine())
                    {
                        case "0": SignInUser(); break;
                        case "1": RegisterUser(); break;
                        default: throw new ArgumentOutOfRangeException();
                    }
                }
                catch (ArgumentOutOfRangeException) { Console.WriteLine("Please, enter correct index of action"); }
                catch (ArgumentNullException) { Console.WriteLine("Please, enter not empty Name/password"); }
                catch (SignInException) { Console.WriteLine("Your Name or Password is incorrect"); }
                catch (RegisterException) { Console.WriteLine("This name has been taken"); }
            }
            ControllerInterface showProducts = new ShowProductsController(Data);
            ControllerInterface replenishAccount = new ReplenishAccountController(User);
            ControllerInterface accountHistory = new AccountHistoryController(Data, User);
            ControllerInterface buyProduct = new BuyProductController(Data, User);
            ControllerInterface exit = new ExitController();

            Controllers = new Dictionary<string, List<ControllerInterface>>();
            Controllers.Add(showProducts.Message(), new List<ControllerInterface>
            {
                buyProduct,
                exit
            });
            Controllers.Add(replenishAccount.Message(), new List<ControllerInterface> { exit });
            Controllers.Add(buyProduct.Message(), new List<ControllerInterface>
            {
                showProducts,
                exit
            });
            Controllers.Add(accountHistory.Message(), new List<ControllerInterface> { exit });
            Controllers.Add(exit.Message(), new List<ControllerInterface>
            {
                showProducts,
                replenishAccount,
                accountHistory
            });
        }
        private void Show(List<ControllerInterface> list) { for (int i = 0; i < list.Count; i++) { Console.WriteLine(i+") "+list[i].Message());} }
        private ControllerInterface Activate(List<ControllerInterface> list, int selected)
        {
            ControllerInterface controller = list.ElementAt(selected);
            controller.Action();
            return controller;
        }
        public void Run()
        {
            Start();
            ControllerInterface controller = new ExitController();
            while (true)
            {
                Console.WriteLine("Hello, {0} you have {1:0.00}$ on your balance.", User.Name,User.Balance);
                do {
                    List<ControllerInterface> listOfController = Controllers[controller.Message()];
                    Show(listOfController);
                    try
                    {
                        controller = Activate(listOfController, int.Parse(Console.ReadLine()));
                    }
                    catch (ArgumentOutOfRangeException) { Console.WriteLine("Please, enter correct index of action"); }
                    catch (NotEnoughMoneyException) { Console.WriteLine("Not Enough Money on balance"); }
                    catch (NegativeBalanceException) { Console.WriteLine("Incorrect amount of money"); }
                    catch (FormatException) { Console.WriteLine("Not supported action"); }
                } while (!controller.Message().Equals("Back to main menu"));
            }
        }
    }
}
