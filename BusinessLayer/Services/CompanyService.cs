using BusinessLayer.Model.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Interfaces;
using System.Threading.Tasks;
using DataAccessLayer.Model.Models;

namespace BusinessLayer.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        public IEnumerable<CompanyInfo> GetAllCompanies()
        {
            var res = _companyRepository.GetAll();
            return _mapper.Map<IEnumerable<CompanyInfo>>(res);
        }

        public CompanyInfo GetCompanyByCode(string companyCode)
        {
            var result = _companyRepository.GetByCode(companyCode);
            return _mapper.Map<CompanyInfo>(result);
        }
        public IEnumerable<CompanyInfo> GetAllCompaniesAsync()
        {
            var res = _companyRepository.GetAllAsync();
             return  _mapper.Map<IEnumerable<CompanyInfo>>(res);
        }

        public IEnumerable<CompanyInfo> GetCompanyByCodeAsync(string companyCode)
        {
            var result = _companyRepository.GetByCodeAsync(companyCode);
            yield return _mapper.Map<CompanyInfo>(result);
        }
        public IEnumerable<bool> SaveCompanyAsync(CompanyInfo company)
        {
            var req = _mapper.Map<Company>(company);

            return (IEnumerable<bool>)_companyRepository.SaveCompanyAsync(req);
            
        }
        public IEnumerable<bool> DeleteCompanyAsync(string id)
        {
            

            return (IEnumerable<bool>)_companyRepository.DeleteCompanyAsync( id);

        }
        
    }
}
