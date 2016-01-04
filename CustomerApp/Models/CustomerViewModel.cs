using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CustomerApp.Model;

namespace CustomerApp.Models
{
    public class CustomerViewModel
    {
        public long Id { get; set; }

        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Surname")]
        public string Surname { get; set; }

        [DisplayName("Phone number")]
        [DataType(DataType.PhoneNumber)]
        public string TelephoneNumber { get; set; }

        [Required]
        [DisplayName("Address")]
        public string Address { get; set; }

        public CustomerViewModel()
        {

        }

        public CustomerViewModel(Customer customer)
        {
            if (customer != null)
            {
                this.Id = customer.Id;
                this.Name = customer.Name;
                this.Surname = customer.Surname;
                this.TelephoneNumber = customer.TelephoneNumber;
                this.Address = customer.Address;
            }
        }
    }
}