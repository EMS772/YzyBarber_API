using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using YzyBarber_API.Data;
using YzyBarber_API.DTO_s.CompanyDTO_s;
using YzyBarber_API.Entities;
using YzyBarber_API.Interfaces;
namespace YzyBarber_API.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly BarberDbContext _dbcontext;
        public CompanyService(BarberDbContext dbcontext) { 
            _dbcontext = dbcontext;
        }
        public CompanyDTO CreateCompany(CreateCompanyDTO companyDTO)
        {
            try
            {
                var exists = _dbcontext.Companies.Any(c =>
                c.CompanyName == companyDTO.CompanyName ||
                c.CompanyEmail == companyDTO.CompanyEmail ||
                c.CompanyPhone == companyDTO.CompanyPhone);

                if (exists)
                {
                    throw new ArgumentException("A company with the same name, email, or phone number already exists.");
                }

                var company = new Company()
                {
                    CompanyName = companyDTO.CompanyName,
                    CompanyEmail = companyDTO.CompanyEmail,
                    CompanyPhone = companyDTO.CompanyPhone,
                };

                _dbcontext.Add(company);
                _dbcontext.SaveChanges();

                return new CompanyDTO()
                {
                    CompanyName = company.CompanyName,
                    CompanyEmail = company.CompanyEmail,
                    CompanyPhone = company.CompanyPhone,
                };
            }
            catch (Exception ex) {
                throw new Exception($"ERROR ON CREATE A COMPANY: {ex}");
            }

        }

        public void DeleteCompany(int id)
        {
            var company = _dbcontext.Companies.FirstOrDefault(c => c.CompanyId==id);

            if (company == null)
            {
                throw new ArgumentException("Company not found");
            }

            _dbcontext.Remove(company);
            _dbcontext.SaveChanges();
        }

        public List<CompanyDTO> GetCompanies()
        {
            var companies = _dbcontext.Companies.Select(c => new CompanyDTO
            {
                CompanyId = c.CompanyId,
                CompanyName = c.CompanyName,
                CompanyEmail = c.CompanyEmail,
                CompanyPhone = c.CompanyPhone
            }).ToList();

            return companies;

        }

        public CompanyDTO UpdateCompany(int Id, CreateCompanyDTO companyDTO)
        {
            var exists = _dbcontext.Companies.Any(c =>
                c.CompanyName == companyDTO.CompanyName ||
                c.CompanyEmail == companyDTO.CompanyEmail ||
                c.CompanyPhone == companyDTO.CompanyPhone);

            if (exists)
            {
                throw new ArgumentException("A company with the same name, email, or phone number already exists.");
            }

            var company = _dbcontext.Companies.FirstOrDefault(c => c.CompanyId == Id);

            if (company == null)
            {
                throw new ArgumentException("Company not found");
            }

            company.CompanyEmail = companyDTO.CompanyEmail;
            company.CompanyPhone = companyDTO.CompanyPhone;
            company.CompanyName = companyDTO.CompanyName;

            _dbcontext.Update(company);
            _dbcontext.SaveChanges();

            return new CompanyDTO
            {
                CompanyEmail = company.CompanyEmail,
                CompanyPhone = company.CompanyPhone,
                CompanyName = company.CompanyName,
            };

        }

       
    }
}
