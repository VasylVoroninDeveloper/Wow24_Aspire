using AutoMapper;
using Client.Clients;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var crmClient = new CrmApiClient(Environment.GetEnvironmentVariable("CRM_API_URL"));
            var tickets =  crmClient.GetTicketsAsync().Result;

            foreach (var ticket in tickets)
                Console.WriteLine($"Отримано тікет: {ticket.Subject}");

            var cxoneClient = new CxoneApiClient(Environment.GetEnvironmentVariable("CXNONE_API_URL"));
            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CrmTicket, CxoneTicket>()
                    .ConstructUsing(src => new CxoneTicket(
                    src.Id,
                    src.Subject,
                    src.Description,
                    src.Created,
                    src.Priority,
                    src.Tags));;
            });
            IMapper mapper = config.CreateMapper();

            foreach (var ticket in tickets)
            {
               
                var cxoneTicket = mapper.Map<CxoneTicket>(ticket);

              //  var cxoneTicket = new CxoneTicket(ticket.Id, ticket.Subject, ticket.Description, ticket.Created, ticket.Priority, ticket.Tags);

                var success = cxoneClient.SendTicketAsync(cxoneTicket).Result;
               
                Console.WriteLine(success
                    ? $"Успішно надіслано тікет {ticket.Id}"
                    : $"Помилка при надсиланні тікета {ticket.Id}");
            }

        }
    }
}
