using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Repositories;

namespace Services
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository employeeRepository;
        public EmployeeService()
        {
            employeeRepository = new EmployeeRepository();
        }
        public bool AuthEmployee(Employees employees)
        {
            return employeeRepository.AuthEmployee(employees);
        }
    }
}
