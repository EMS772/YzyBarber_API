using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using YzyBarber_API.DTO_s.CompanyDTO_s;
using YzyBarber_API.Interfaces;
using YzyBarber_API.Services;

namespace YzyBarber_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        [Route("GetCompanies")]
        public IActionResult GetCompanies()
        {
            var companies = _companyService.GetCompanies();
            return Ok(companies);
        }

        [HttpPost]
        [Route("CreateCompanies")]
        public IActionResult CreateCompanies([FromBody] CreateCompanyDTO CompanyDTO)
        {
            var createdCompany = _companyService.CreateCompany(CompanyDTO);
            return Ok(new { succes=true, message="Company created correctly" });

        }

        [HttpPut]
        [Route("UpdateCompany/{id}")]
        public IActionResult UpdateCompany(int id, [FromBody] CreateCompanyDTO companyDTO)
        {
            var updatedCompany = _companyService.UpdateCompany(id, companyDTO);
            return Ok(new { succes = true, message = "Company updated correctly" });
        }

        [HttpDelete]
        [Route("DeleteCompany/{id}")]
        public IActionResult DeleteCompany(int id )
        {
            _companyService.DeleteCompany(id);

            return Ok(new { succes = true, message="Company deleted correctly"});
        }
    }
}
