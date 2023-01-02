namespace Lab3.Model
{
    internal class History
    {
        public Account Account { get; set; }
        public Product Product { get; set; }
        public History(Account account, Product product)
        {
            Account = account;
            Product = product;
        }
    }
}
