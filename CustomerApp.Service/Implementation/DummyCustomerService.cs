using CustomerApp.Service.Interface;
using System;
using System.Linq;
using CustomerApp.Model;
using System.Collections.Generic;

namespace CustomerApp.Service.Implementation
{
    public class DummyCustomerService : ICustomerService
    {
        List<Customer> customers = new List<Customer>();

        private int getNextCustomerId()
        {
            Func<int> customerId = () => { return customers.Count + 1; };

            int id = customerId();

            return id;
        }

        public DummyCustomerService()
        {

            int id = getNextCustomerId();

            customers.Add(new Customer() { Id = id, Address = "Address" , Name = "Name" + id, Surname = "Surname" + id, TelephoneNumber = "Phone" + id });

            id = getNextCustomerId();    
            customers.Add(new Customer() { Id = id, Address = "Address", Name = "Name" + id, Surname = "Surname" + id, TelephoneNumber = "Phone" + id });

            id = getNextCustomerId();
            customers.Add(new Customer() { Id = id, Address = "Address", Name = "Name" + id, Surname = "Surname" + id, TelephoneNumber = "Phone" + id });

            id = getNextCustomerId();
            customers.Add(new Customer() { Id = id, Address = "Address", Name = "Name" + id, Surname = "Surname" + id, TelephoneNumber = "Phone" + id });
        }


        public long Add(string name, string surname, string phone, string address)
        {
            int id = getNextCustomerId();

            customers.Add(new Customer() { Id = id, Address = address, Name = name, Surname =surname, TelephoneNumber = phone });

            return id;
        }

        public bool Delete(long id)
        {
            if(customers.Any(r=>r.Id == id))
            {
                return customers.RemoveAll(r => r.Id == id) > 0;
            }
            return false;
        }

        public IQueryable<Customer> GetAll()
        {
            return customers.AsQueryable();
        }

        public Customer GetById(long id)
        {
            return customers.Where(r => r.Id == id).SingleOrDefault();
        }

        public bool Update(long id, string name, string surname, string phone, string address)
        {
            if (customers.Any(r => r.Id == id))
            {
                Customer customer = customers.FirstOrDefault(r => r.Id == id);
                if (customer != null)
                {
                    customer.Name = name;
                    customer.Surname = surname;
                    customer.TelephoneNumber = phone;
                    customer.Address = address;
                    return true;
                }
            }
            return false;
        }
    }
}
