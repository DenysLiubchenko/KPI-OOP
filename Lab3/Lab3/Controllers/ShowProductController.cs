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
                Console.WriteLine(i++ + " " + category);
                int j = 0;
                foreach (Product product in Data.Categories[category])
                {
                    Console.WriteLine("\t"+j++ + ") " + product.Name + " - " + product.Price + "$");
                }
            }
        }
    }
}
