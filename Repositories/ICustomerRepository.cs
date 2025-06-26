using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAcessLayer;

namespace Repositories
{
    public interface ICustomerRepository
    {
        public List<Customers> getAllCustomers();
        public bool CreateCustomer(Customers customer);
        public bool UpdateCustomer(Customers customer);
        public bool DeleteCustomer(Customers customer);
        public bool AuthCustomer(Customers customer);
        public Customers GetCustByPhone(string phone);
        public Customers GetCustomerById(int id);
    }
}
