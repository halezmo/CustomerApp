using CustomerApp.Model;
using CustomerApp.Service.Interface;
using System.Linq;

namespace CustomerApp.Service
{
    public class CustomerService : ICustomerService
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new CustomerModel());

        public CustomerService()
        {
        }

        public long Add(string name, string surname, string phone, string address)
        {
            var customer = new Customer() {Name = name, Surname = surname, TelephoneNumber = phone, Address = address};
            unitOfWork.Repository<Customer>().Insert(customer);
            return customer.Id;
        }

        public IQueryable<Customer> GetAll()
        {
            var items = unitOfWork.Repository<Customer>().Table;
            return items;
        }

        public Customer GetById(long id)
        {
            var item = unitOfWork.Repository<Customer>().GetById(id);
            return item;
        }

        public bool Update(long id, string name, string surname, string phone, string address)
        {
            Customer customer = GetById(id);
            var updated = false;
            if (customer != null)
            {
                customer.Name = name;
                customer.Surname = surname;
                customer.TelephoneNumber = phone;
                customer.Address = address;
                unitOfWork.Repository<Customer>().Update(customer);
                updated = true;
            }
            return updated;
        }

        public bool Delete(long id)
        {
            Customer customer = GetById(id);
            if (customer != null)
            {
                unitOfWork.Repository<Customer>().Delete(customer);
                return true;
            }
            return false;
        }
    }
}
