using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YzyBarber_API.DTO_s.BranchDTO_s;
using YzyBarber_API.Interfaces;
using YzyBarber_API.Services;

namespace YzyBarber_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;
        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet]
        [Route("GetBranches")]
        public IActionResult GetBranches()
        {

            var branches = _branchService.GetBranches();
            return Ok(branches);

        }

        [HttpPost]
        [Route("CreateBranch")]
        public IActionResult CreateBranch([FromBody] CreateBranchDTO branchDTO)
        {
            var createdBranch = _branchService.CreateBranch(branchDTO);
            return Ok(new { success = true, message = "Branch created correctly" });
        }

        [HttpPut]
        [Route("UpdateBranch/{id}")]
        public IActionResult UpdateBranch(int id, [FromBody] CreateBranchDTO branchDTO)
        {
            var updatedBranch = _branchService.UpdateBranch(id, branchDTO);
            return Ok(new { success = true, message = "Branch updated correctly" });
        }
        [HttpDelete]
        [Route("DeleteBranch/{id}")]
        public IActionResult DeleteBranch(int id)
        {
            _branchService.DeleteBranch(id);
            return Ok(new { success = true, message = "Branch deleted correctly" });
        }
    }
}
