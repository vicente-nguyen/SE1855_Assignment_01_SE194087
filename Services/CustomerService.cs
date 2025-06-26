using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Repositories;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepository irepository;
        public CustomerService()
        {
            irepository = new CustomerRepository();
        }

        public bool AuthCustomer(Customers customer)
        {
            return irepository.AuthCustomer(customer);
        }

        public bool CreateCustomer(Customers customer)
        {
            return irepository.CreateCustomer(customer);
        }

        public bool DeleteCustomer(Customers customer)
        {
            return irepository.DeleteCustomer(customer);
        }

        public List<Customers> getAllCustomers()
        {
            return irepository.getAllCustomers();
        }

        public Customers GetCustByPhone(string phone)
        {
            return irepository.GetCustByPhone(phone);
        }

        public Customers GetCustomerById(int id)
        {
            return irepository.GetCustomerById(id);
        }

        public bool UpdateCustomer(Customers customer)
        {
            return irepository.UpdateCustomer(customer);
        }
    }
}
