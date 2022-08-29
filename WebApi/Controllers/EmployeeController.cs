using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using Microsoft.Build.Tasks;
using WebApi.Logger;
using WebApi.Models;


namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }
        // GET api/<controller>
        public IEnumerable<EmployeeDto> GetAll()
        {
            try {
                var items = _employeeService.GetAllEmployees();
                return _mapper.Map<IEnumerable<EmployeeDto>>(items);
            }
            catch (Exception ex)
            {
                EventLogger.LogError(ex.Message + " " + ex.StackTrace);

                return null;
            }
}

        // GET api/<controller>/5
        public EmployeeDto Get(string employeeCode)
        {
            try { 

                var item = _employeeService.GetEmployeeByCode(employeeCode);
                return _mapper.Map<EmployeeDto>(item);
             }
            catch (Exception ex)
            {
                EventLogger.LogError(ex.Message + " " + ex.StackTrace);

                return null;
            }
}
        // GET api/<controller>
        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            try { 
                var items = _employeeService.GetAllEmployeesAsync();
                return _mapper.Map<IEnumerable<EmployeeDto>>(items);
            }
            catch (Exception ex)
            {
                EventLogger.LogError(ex.Message + " " + ex.StackTrace);

                return null;
            }
        }

        // GET api/<controller>/5
        public async Task<EmployeeDto> GetAsync(string employeeCode)
        {
            try
            {
                var item = _employeeService.GetEmployeeByCodeAsync(employeeCode);
                return _mapper.Map<EmployeeDto>(item);
            }
            catch (Exception ex)
            {
                EventLogger.LogError(ex.Message + " " + ex.StackTrace);

                return null;
            }
        }

        // POST api/<controller>
        public async Task<IEnumerable<bool>> Post([FromBody] EmployeeDto employee)
        {
            try { 
                var emp = _mapper.Map<EmployeeInfo>(employee);
                return _employeeService.SaveEmployeeAsync(emp);
            }
            catch (Exception ex)
            {
                EventLogger.LogError(ex.Message + " " + ex.StackTrace);
                return null;
              //  return (IEnumerable<bool>) Task.FromException(ex);
            }
        }

        // PUT api/<controller>/5 //update
        public async Task<IEnumerable<bool>> Put(string id, [FromBody] EmployeeDto employee)
        {
            try
            {

                if (string.IsNullOrEmpty(employee.SiteId))
                {
                    employee.SiteId = id;
                }
                var comp = _mapper.Map<EmployeeInfo>(employee);
                return _employeeService.SaveEmployeeAsync(comp);
            }
            catch (Exception ex)
            {
                EventLogger.LogError(ex.Message + " " + ex.StackTrace);

                return null;
            }
        }

        // DELETE api/<controller>/5
        //public async Task<IEnumerable<bool>> Delete(string id)
        //{

        //    return _employeeService.DeleteEmployeeAsync(id);
        //}
    }
}