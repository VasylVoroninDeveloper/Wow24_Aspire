namespace CRM.ApiService.Models
{
    public record Ticket(string Id, string Subject, string Description, DateTime Created, string Priority, List<string> Tags);
}
