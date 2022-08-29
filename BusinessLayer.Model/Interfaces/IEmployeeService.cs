﻿using System;
using System.Collections.Generic;
using BusinessLayer.Model.Models;

namespace BusinessLayer.Model.Interfaces
{
  public  interface IEmployeeService
    {
        IEnumerable<EmployeeInfo> GetAllEmployees();
        EmployeeInfo GetEmployeeByCode(string employeeCode);
        IEnumerable<EmployeeInfo> GetAllEmployeesAsync();
        IEnumerable<EmployeeInfo> GetEmployeeByCodeAsync(string employeeCode);
        IEnumerable<bool> SaveEmployeeAsync(EmployeeInfo employee);
        IEnumerable<bool> DeleteEmployeeAsync(string id);
        object GetAllCompaniesAsync();
    }
}
