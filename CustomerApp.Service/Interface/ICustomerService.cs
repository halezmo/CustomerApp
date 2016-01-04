using CustomerApp.Model;
using System.Linq;

namespace CustomerApp.Service.Interface
{
    public interface ICustomerService
    {
        IQueryable<Customer> GetAll();
        long Add(string name, string surname, string phone, string address);
        Customer GetById(long id);
        bool Update(long id, string name, string surname, string phone, string address);
        bool Delete(long id);
    }
}
