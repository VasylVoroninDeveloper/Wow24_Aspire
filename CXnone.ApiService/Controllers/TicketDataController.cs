using CXnone.ApiService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CXnone.ApiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketDataController : ControllerBase
    {
        private readonly ILogger<TicketDataController> logger;
                                                                                                  
        public TicketDataController(ILogger<TicketDataController> logger)
        {
            this.logger = logger;
        }

        [HttpPost(Name = "SaveTicket")]
        public IActionResult Post(Ticket ticket)
        {
            if (ticket == null)
                return BadRequest("Request empty");

            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(ticket, options);

            System.IO.File.WriteAllText("tickets.json", json);

            return Ok();
        }
    }
}
