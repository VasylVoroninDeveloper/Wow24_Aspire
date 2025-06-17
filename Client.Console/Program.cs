using Client.Clients;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var crmHttpClient = new HttpClient();
            var crm_url = Environment.GetEnvironmentVariable("CRM_API_URL");
            crmHttpClient.BaseAddress = new Uri(crm_url);//поміняти
            var crmClient = new CrmApiClient(crmHttpClient);
            var tickets =  crmClient.GetTicketsAsync().Result;

            foreach (var ticket in tickets)
            {
                Console.WriteLine($"Отримано тікет: {ticket.Subject}");
            }

            var cxnone_url = Environment.GetEnvironmentVariable("CXNONE_API_URL");
            var cxnoneHttpClient = new HttpClient();
            cxnoneHttpClient.BaseAddress = new Uri(cxnone_url);//поміняти
            var cxoneClient = new CxoneApiClient(cxnoneHttpClient);

            foreach (var ticket in tickets)
            {
                var cxoneTicket = new CxoneTicket(ticket.Id, ticket.Subject, ticket.Description, ticket.Created, ticket.Priority, ticket.Tags);

                var success = cxoneClient.SendTicketAsync(cxoneTicket).Result;
               
                Console.WriteLine(success
                    ? $"Успішно надіслано тікет {ticket.Id}"
                    : $"Помилка при надсиланні тікета {ticket.Id}");
            }

        }      
        
        

    }
}
