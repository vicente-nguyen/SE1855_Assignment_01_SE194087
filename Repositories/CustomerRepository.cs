using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAcessLayer;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        CustomerDAO customerDAO = new CustomerDAO();

        public bool AuthCustomer(Customers customer)
        {
            return customerDAO.AuthCustomer(customer);
        }

        public bool CreateCustomer(Customers customer)
        {
            return customerDAO.CreateCustomer(customer);
        }

        public bool DeleteCustomer(Customers customer)
        {
            return customerDAO.DeleteCustomer(customer);
        }

        public List<Customers> getAllCustomers()
        {
            return customerDAO.getAllCustomers();
        }

        public Customers GetCustByPhone(string phone)
        {
            return customerDAO.GetCustByPhone(phone);
        }

        public Customers GetCustomerById(int id)
        {
            return customerDAO.GetCustomerById(id);
        }

        public bool UpdateCustomer(Customers customer)
        {
            return customerDAO.UpdateCustomer(customer);
        }
    }
}
