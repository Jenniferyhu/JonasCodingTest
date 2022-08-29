using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Model.Models;

namespace BusinessLayer.Model.Interfaces
{
    public interface ICompanyService
    {
        IEnumerable<CompanyInfo> GetAllCompanies();
        CompanyInfo GetCompanyByCode(string companyCode);
      IEnumerable<CompanyInfo> GetAllCompaniesAsync();
        IEnumerable<CompanyInfo> GetCompanyByCodeAsync(string companyCode);
        IEnumerable <bool> SaveCompanyAsync(CompanyInfo company);
        IEnumerable<bool> DeleteCompanyAsync(string id);
    }
}
