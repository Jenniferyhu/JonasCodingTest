using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Model.Models;

namespace DataAccessLayer.Model.Interfaces
{
    public interface IEmployeeRepository
    {

        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployeeByCode(string employeeCode);

        IEnumerable<Employee> GetAllEmployeeAsync();

        IEnumerable<Employee> GetEmployeeByCodeAsync(string employeeCode);

        bool SaveEmployee(Employee employee);
        IEnumerable<bool> SaveEmployeeAsync(Employee employee);
       
    }
}
