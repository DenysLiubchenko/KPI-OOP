using Lab3.Exeptions;
using Lab3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Controllers
{
    internal class RegistrationController : ControllerInterface
    {
        private DataBase Data;
        public RegistrationController(DataBase data) { Data = data; }
        public string Message() { return "Register Account"; }
        public void Action()
        {
            string name;
            Console.WriteLine("Enter your Name: ");
            name = Console.ReadLine();
            if (Data.FindAccountByName(name) != null) throw new RegisterException();
            Console.WriteLine("Enter your Password: ");
            string password = Console.ReadLine();
            if (password.Equals("") || name.Equals("")) throw new ArgumentNullException();
            Data.CreateAccount(name, new Hasher().CalculateHashCode(password));
        }
    }
}
