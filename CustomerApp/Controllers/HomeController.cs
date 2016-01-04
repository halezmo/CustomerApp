using CustomerApp.Models;
using CustomerApp.Service.Interface;
using System.Linq;
using System.Web.Mvc;

namespace CustomerApp.Controllers
{
    public class HomeController : BaseController
    {
        private ICustomerService _customerService;

        public HomeController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About Customer app";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Customer App contact";

            return View();
        }
    }
}