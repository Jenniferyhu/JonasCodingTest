using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;

namespace DataAccessLayer.Repositories
{
   public class EmployeeRepository: IEmployeeRepository { 
     private readonly IDbWrapper<Employee> _employeeDbWrapper;

    public EmployeeRepository(IDbWrapper<Employee> EmployeeDbWrapper)
    {
        _employeeDbWrapper = EmployeeDbWrapper;
    }

    public IEnumerable<Employee> GetAllEmployee()
    {
        return _employeeDbWrapper.FindAll();
    }

    public Employee GetEmployeeByCode(string EmployeeCode)
    {
        return _employeeDbWrapper.Find(t => t.EmployeeCode.Equals(EmployeeCode))?.FirstOrDefault();
    }

    public IEnumerable<Employee> GetAllEmployeeAsync()
    {
        return (IEnumerable<Employee>)_employeeDbWrapper.FindAllAsync();
    }

    public IEnumerable<Employee> GetEmployeeByCodeAsync(string EmployeeCode)
    {
        return (IEnumerable<Employee>)_employeeDbWrapper.FindAsync(t => t.EmployeeCode.Equals(EmployeeCode));
    }


    public bool SaveEmployee(Employee employee)
    {
        var itemRepo = _employeeDbWrapper.Find(t =>
            t.SiteId.Equals(employee.SiteId) && t.EmployeeCode.Equals(employee.EmployeeCode))?.FirstOrDefault();
        if (itemRepo != null)
        {
            itemRepo.EmployeeName = employee.EmployeeName;
            itemRepo.CompanyCode = employee.CompanyCode;
            itemRepo.EmailAddress = employee.EmailAddress;
            itemRepo.EmployeeStatus = employee.EmployeeStatus;
            itemRepo.Phone = employee.Phone;
            itemRepo.Occupation = employee.Occupation;
            itemRepo.LastModified = employee.LastModified;
            return _employeeDbWrapper.Update(itemRepo);
        }

        return _employeeDbWrapper.Insert(employee);
    }

    public IEnumerable<bool> SaveEmployeeAsync(Employee employee)
    {
        var itemRepo = _employeeDbWrapper.Find(t =>
          t.SiteId.Equals(employee.SiteId) && t.EmployeeCode.Equals(employee.EmployeeCode))?.FirstOrDefault();
        if (itemRepo != null)
        {
                itemRepo.EmployeeName = employee.EmployeeName;
                itemRepo.CompanyCode = employee.CompanyCode;
                itemRepo.EmailAddress = employee.EmailAddress;
                itemRepo.EmployeeStatus = employee.EmployeeStatus;
                itemRepo.Phone = employee.Phone;
                itemRepo.Occupation = employee.Occupation;
                itemRepo.LastModified = employee.LastModified;
             
                return (IEnumerable<bool>)_employeeDbWrapper.UpdateAsync(itemRepo);
        }

        return (IEnumerable<bool>)_employeeDbWrapper.InsertAsync(employee);
    }
    public IEnumerable<bool> DeleteemployeeAsync(string id)
    {

        return (IEnumerable<bool>)_employeeDbWrapper.DeleteAsync(t => t.EmployeeCode.Equals(id));


    }

}
}
