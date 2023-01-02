using Lab3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Controllers
{
    internal class ExitController : ControllerInterface
    {
        private DataBase Data;
        public string Message() { return "Exit program"; }
        public ExitController(DataBase data) { Data = data; }
        public void Action()
        {
            new Serializer().Serialize("C:\\Laba\\Project\\OOP\\Lab3\\Lab3\\Data\\Data.json", Data);
            Environment.Exit(0);
        }
    }
}
