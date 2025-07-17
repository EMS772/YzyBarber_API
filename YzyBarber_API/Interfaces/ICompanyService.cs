using YzyBarber_API.DTO_s.CompanyDTO_s;

namespace YzyBarber_API.Interfaces
{
    public interface ICompanyService
    {
        public List<CompanyDTO> GetCompanies();
        public CompanyDTO CreateCompany(CreateCompanyDTO companyDTO);
        public CompanyDTO UpdateCompany(int Id, CreateCompanyDTO companyDTO);
        public void DeleteCompany(int id);
    }
}
