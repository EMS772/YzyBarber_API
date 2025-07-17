using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YzyBarber_API.DTO_s.AppointmentDTO_s;
using YzyBarber_API.Interfaces;

namespace YzyBarber_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        [Route("GetAppointments")]
        public IActionResult GetAppointments()
        {
            var appointments = _appointmentService.GetAppointments();
            return Ok(appointments);
        }

        [HttpPost]
        [Route("CreateAppointment")]
        public IActionResult CreateAppointment([FromBody] CreateAppointmentDTO appointmentDTO)
        {
            var createdAppointment = _appointmentService.CreateAppointment(appointmentDTO);
            return Ok(new { success = true, message = "Appointment created successfully" });
        }

        [HttpPut]
        [Route("UpdateAppointment/{id}")]
        public IActionResult UpdateAppointment(int id, [FromBody] CreateAppointmentDTO appointmentDTO)
        {
            var updatedAppointment = _appointmentService.UpdateAppointment(id, appointmentDTO);
            return Ok(new { success = true, message = "Appointment updated successfully" });
        }

        [HttpDelete]
        [Route("DeleteAppointment/{id}")]
        public IActionResult DeleteAppointment(int id)
        {
            _appointmentService.DeleteAppointment(id);
            return Ok(new { success = true, message = "Appointment deleted successfully" });
        }
    }
}
