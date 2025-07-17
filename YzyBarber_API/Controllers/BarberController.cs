using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YzyBarber_API.DTO_s.BarberDTO_s;
using YzyBarber_API.Interfaces;

namespace YzyBarber_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarberController : ControllerBase
    {
        private readonly IBarberService _barberService;
        public BarberController(IBarberService barberService)
        {
            _barberService = barberService;
        }

        [HttpGet]
        [Route("GetBarbers")]
        public IActionResult GetBarbers()
        {
            var barbers = _barberService.GetBarbers();
            return Ok(barbers);
        }

        [HttpPost]
        [Route("CreateBarber")]
        public IActionResult CreateBarber([FromBody] CreateBarberDTO barberDTO)
        {
            var createdBarber = _barberService.CreateBarber(barberDTO);
            return Ok(new { success = true, message = "Barber created correctly" });
        }

        [HttpPut]
        [Route("UpdateBarber/{id}")]
        public IActionResult UpdateBarber(int id, [FromBody] CreateBarberDTO barberDTO)
        {
            var updatedBarber = _barberService.UpdateBarber(id, barberDTO);
            return Ok(new { success = true, message = "Barber updated correctly" });
        }

        [HttpDelete]
        [Route("DeleteBarber/{id}")]
        public IActionResult DeleteBarber(int id)
        {
            _barberService.DeleteBarber(id);
            return Ok(new { success = true, message = "Barber deleted correctly" });
        }
    }
}
