using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YzyBarber_API.DTO_s.ClientDTO_s;
using YzyBarber_API.Interfaces;

namespace YzyBarber_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        [Route("GetClients")]
        public IActionResult GetClients()
        {
            var clients = _clientService.GetClients();
            return Ok(clients);
        }

        [HttpPost]
        [Route("CreateClient")]
        public IActionResult CreateClients([FromBody] CreateClientDTO client)
        {
            var clients = _clientService.CreateClient(client);
            return Ok(new { success = true, message = "Client created succesfully" });
        }

        [HttpPut]
        [Route("UpdateClient/{id}")]
        public IActionResult UpdateClients(int id, [FromBody] CreateClientDTO Cliente)
        {
            var clients = _clientService.UpdateClient(id, Cliente);
            return Ok(new { success = true, message = "Client update succesfully" });
        }

        [HttpDelete]
        [Route("DeleteClient/{id}")]
        public IActionResult DeleteClients(int id)
        {
            _clientService.DeleteClient(id);
            return Ok(new { success = true, message = "Client deleted succesfully" });
        }
    }
}
