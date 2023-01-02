using Lab3.Exeptions;

namespace Lab3.Controllers
{
    internal class ReturnController : ControllerInterface
    {
        public string Message() { return "Return to main menu"; }
        public void Action()
        {
            throw new ReturnException();
        }
    }
}
