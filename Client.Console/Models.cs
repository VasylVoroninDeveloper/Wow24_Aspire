using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{

    public record CrmTicket(string Id, string Subject, string Description, DateTime Created, string Priority, List<string> Tags);

    public record CxoneTicket(string TicketId, string Subject, string Description, DateTime Created, string Priority, List<string> Tags);

}
