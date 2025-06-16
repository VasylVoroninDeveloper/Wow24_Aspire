using Client.Clients;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7154/");//поміняти

            var crmClient = new CrmApiClient(httpClient);
            var tickets =  crmClient.GetTicketsAsync().Result;

            foreach (var ticket in tickets)
            {
                Console.WriteLine($"Отримано тікет: {ticket.Subject}");
            }

            httpClient.BaseAddress = new Uri("https://localhost:7267/");//поміняти

            var cxoneClient = new CxoneApiClient(httpClient);

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
