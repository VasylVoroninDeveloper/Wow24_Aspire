namespace CXnone.ApiService.Models
{
    public record Ticket(string TicketId, string Subject, string Description, DateTime Created, string Priority, List<string> Tags);
}
