using CustomerApp.Models;
using CustomerApp.Service.Interface;
using System.Linq;
using System.Web.Mvc;

namespace CustomerApp.Controllers
{
    public class CustomerController : BaseController
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: Customer
        public ActionResult Index()
        {
            var items = _customerService.GetAll();

            var customers = items.Select(r => new CustomerViewModel() { Id = r.Id, Name = r.Name, Address = r.Address, Surname = r.Surname, TelephoneNumber = r.TelephoneNumber });

            return View(customers);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            var customerVm = GetCustomer(id);

            return View(customerVm);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            var customer = new CustomerViewModel();

            return View(customer);
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(CustomerViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var id = _customerService.Add(viewModel.Name, viewModel.Surname, viewModel.TelephoneNumber, viewModel.Address);
                    AddMessage(id > 0, "Customer added");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(viewModel);
            }
        }
 
        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var customerVm = GetCustomer(id);

            return View(customerVm);
        }

        private CustomerViewModel GetCustomer(long id)
        {
            var customer = _customerService.GetById(id);
            if (customer == null)
                return null;

            var customerVm = new CustomerViewModel(customer);
            return customerVm;
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CustomerViewModel viewModel)
        {
            try
            {
                if (viewModel != null)
                {
                    var updated =_customerService.Update(id, viewModel.Name, viewModel.Surname, viewModel.TelephoneNumber, viewModel.Address);
                    AddMessage(updated, "Customer updated");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            var customerVm = GetCustomer(id);

            return View(customerVm);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (id > 0)
                {
                    var deleted =_customerService.Delete(id);
                    AddMessage(deleted, "Customer deleted");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
