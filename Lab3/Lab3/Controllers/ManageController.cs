using Lab3.Exeptions;
using Lab3.Model;

namespace Lab3.Controllers
{
    internal class ManageController
    {
        private const string FileName = "C:\\Laba\\Project\\OOP\\Lab3\\Lab3\\Data\\Data.json";
        private Dictionary<string, List<ControllerInterface>> Controllers { get; set; }
        private Account User { get; set; }
        private DataBase Data { get; set; }
        public ManageController()
        {
            Data = new Serializer().Deserialize(FileName);
        }
        private void SignInUser()
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();
            Account account = Data.FindAccountByName(name);
            if (account == null || !ComputeHash(password).Equals(account.Password)) throw new SignInException();
            User = account;
        }
        private string ComputeHash(string password)
        {
            return new Hasher().CalculateHashCode(password);
        }    
        private void Start() 
        {
            ControllerInterface exit = new ExitController(Data);
            ControllerInterface register = new RegistrationController(Data);
            while (User == null)
            {
                Console.WriteLine("0) Sign in Account\n" + "1) " + register.Message() + "\n2) " + exit.Message());
                try
                {
                    switch (Console.ReadLine())
                    {
                        case "0": SignInUser();break;
                        case "1": new RegistrationController(Data).Action(); Console.WriteLine("Registration successful"); break;
                        case "2": new ExitController(Data).Action(); break;
                        default: throw new ArgumentOutOfRangeException();
                    }
                }
                catch (ArgumentOutOfRangeException) { Console.WriteLine("Please, enter correct index of action"); }
                catch (ArgumentNullException) { Console.WriteLine("Please, enter not empty Name/password"); }
                catch (SignInException) { Console.WriteLine("Incorrect Login or Password"); }
                catch (RegisterException) { Console.WriteLine("This name has been taken"); }
            }

            ControllerInterface showProducts = new ShowProductsController(Data);
            ControllerInterface replenishAccount = new ReplenishAccountController(User);
            ControllerInterface accountHistory = new AccountHistoryController(Data, User);
            ControllerInterface buyProduct = new BuyProductController(Data, User);
            ControllerInterface returnToMainMenu = new ReturnController();
            Controllers = new Dictionary<string, List<ControllerInterface>>();
            Controllers.Add(showProducts.Message(), new List<ControllerInterface>
            {
                buyProduct,
                returnToMainMenu,
                exit
            });
            Controllers.Add(replenishAccount.Message(), new List<ControllerInterface> 
            {
                returnToMainMenu,
                exit
            });
            Controllers.Add(buyProduct.Message(), new List<ControllerInterface>
            {
                showProducts,
                returnToMainMenu,
                exit
            });
            Controllers.Add(accountHistory.Message(), new List<ControllerInterface> 
            {
                returnToMainMenu,
                exit
            });
            Controllers.Add(returnToMainMenu.Message(), new List<ControllerInterface>
            {
                showProducts,
                replenishAccount,
                accountHistory,
                exit
            });
        }
        private void Show(List<ControllerInterface> list) 
        { 
            for (int i = 0; i < list.Count; i++) 
            { 
                Console.WriteLine(i+") "+list[i].Message());
            } 
        }
        private ControllerInterface Activate(List<ControllerInterface> list, int selected)
        {
            ControllerInterface controller = list.ElementAt(selected);
            controller.Action();
            return controller;
        }
        public void Run()
        {
            Start();
            while (true)
            {
                ControllerInterface controller = new ReturnController();
                Console.WriteLine("Hello, {0} you have {1:0.00}$ on your balance.", User.Name, User.Balance);
                while (true) {
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
                    catch (ReturnException) { break; }
                }
            }
        }
    }
}
