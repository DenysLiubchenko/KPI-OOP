namespace Lab3.Model
{
    internal class DataBase
    {
        public uint AccountID { get; set; }
        public uint ProductID { get; set; }
        public List<Account> Accounts { get; set; }
        public List<History> History { get; set; }
        public Dictionary<string, List<Product>> Categories { get; set; }
        public DataBase()
        {
            AccountID = ProductID = 0;
            Accounts = new List<Account>();
            Categories = new Dictionary<string, List<Product>>();
            Categories.Add("Electronics", new List<Product>
            {
                CreateProduct("Apple AirPods", 17.95),
                CreateProduct("Nintendo Switch", 19.99),
                CreateProduct("Apple MacBook Air Laptop", 99.99),
                CreateProduct("AMD Ryzen 9 5900X", 362.99)
            });
            Categories.Add("Toys", new List<Product>
            {
                CreateProduct("Slinky Walking Spring Toy", 2.99),
                CreateProduct("Jenga", 6.99),
                CreateProduct("UNO Card Game", 7.99),
                CreateProduct("NERF DinoSquad Blaster", 20.99)
            });
            History = new List<History>();
        }
        public Account CreateAccount(string name, string password)
        {
            Account account = new Account(name, password);
            account.ID = AccountID++;
            Accounts.Add(account);
            return account;
        }
        public List<History> GetHistoryOfAccount(uint accountID)
        {
            return History.FindAll(hist => hist.Account.ID == accountID);
        }
        public Account FindAccountByName(string name)
        {
            return Accounts.Find(account => account.Name == name);
        }
        private Product CreateProduct(string name, double price)
        {
            Product product = new Product(name, price);
            product.ID = ProductID++;
            return product;
        }
    }
}
