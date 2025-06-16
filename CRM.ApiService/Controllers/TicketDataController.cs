using CRM.ApiService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CRM.ApiService.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketDataController : ControllerBase
{
    private readonly ILogger<TicketDataController> _logger;
    public TicketDataController(ILogger<TicketDataController> logger)
    {
        _logger = logger;
    }
    private List<Ticket> GetMockTickets() => new()
    {
        new Ticket(
            Id: "TCK-001",
            Subject: "Login issue",
            Description: "User cannot log in to the system.",
            Created: DateTime.UtcNow.AddDays(-2),
            Priority: "High",
            Tags: new List<string> { "login", "auth", "urgent" }
        ),
        new Ticket(
            Id: "TCK-002",
            Subject: "Payment failed",
            Description: "Customer's payment did not go through.",
            Created: DateTime.UtcNow.AddDays(-1),
            Priority: "Medium",
            Tags: new List<string> { "payment", "checkout" }
        ),
        new Ticket(
            Id: "TCK-003",
            Subject: "Feature request",
            Description: "User requested a dark mode feature.",
            Created: DateTime.UtcNow,
            Priority: "Low",
            Tags: new List<string> { "feature", "ui", "request" }
        )
    };

    [HttpGet("GetTickets")]
    public IEnumerable<Ticket> Get()
    {
        return GetMockTickets();
    }
}

