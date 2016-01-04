using System.Web.Mvc;

namespace CustomerApp.Controllers
{
    public class BaseController : Controller
    {
        public void AddMessage(bool condition, string message)
        {
            if (condition)
                TempData["Message"] = message;
        }
    }
}