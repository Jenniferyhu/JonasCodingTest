using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using WebApi.Logger;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }
        // GET api/<controller>
        public IEnumerable<CompanyDto> GetAll()
        {
            try
            {
                var items = _companyService.GetAllCompanies();
                return _mapper.Map<IEnumerable<CompanyDto>>(items);
            }
            catch (Exception ex)
            {
                EventLogger.LogError(ex.Message + " " + ex.StackTrace);

                return null;
            }
}

        // GET api/<controller>/5
        public CompanyDto Get(string companyCode)
        {    try { 
                var item = _companyService.GetCompanyByCode(companyCode);
                return _mapper.Map<CompanyDto>(item);
            }
            catch (Exception ex)
            {
                EventLogger.LogError(ex.Message + " " + ex.StackTrace);

                return null;
            }
        
            
         }
        // GET api/<controller>
        public async Task<IEnumerable<CompanyDto>> GetAllAsync()
        {
            try { 
            var items =  _companyService.GetAllCompaniesAsync();
            return _mapper.Map<IEnumerable<CompanyDto>>(items);
            }
            catch (Exception ex)
            {
                EventLogger.LogError(ex.Message + " " + ex.StackTrace);

                return null;
            }
}

        // GET api/<controller>/5
        public async Task<CompanyDto> GetAsync(string companyCode)
        {
            try { 
                var item =  _companyService.GetCompanyByCodeAsync(companyCode);
                return _mapper.Map<CompanyDto>(item);
             }
            catch (Exception ex)
            {
                EventLogger.LogError(ex.Message + " " + ex.StackTrace);

                return null;
            }
}

        // POST api/<controller>
        public async Task<IEnumerable<bool>> Post([FromBody] CompanyDto company)
        {
            try { 
                 var comp = _mapper.Map<CompanyInfo>(company);
                 return _companyService.SaveCompanyAsync(comp);
            }
            catch (Exception ex)
            {
                EventLogger.LogError(ex.Message + " " + ex.StackTrace);

                return null;
            }
}

        // PUT api/<controller>/5 //update
        public async Task<IEnumerable<bool>> Put(string id, [FromBody] CompanyDto company)
        {
            try { 
            if (string.IsNullOrEmpty(company.CompanyCode)) { 
                company.CompanyCode = id;
            }
            var comp = _mapper.Map<CompanyInfo>(company);
            return _companyService.SaveCompanyAsync(comp);
        }
            catch (Exception ex)
            {
                EventLogger.LogError(ex.Message + " " + ex.StackTrace);

                return null;
            }
}

        // DELETE api/<controller>/5
        public async Task<IEnumerable<bool>> Delete(string id)
        {
          
            return _companyService.DeleteCompanyAsync(id);
        }
    }
}