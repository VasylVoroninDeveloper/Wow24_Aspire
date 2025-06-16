using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client.Clients
{
    internal class CxoneApiClient
    {

        private readonly HttpClient _httpClient;

        public CxoneApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> SendTicketAsync(CxoneTicket ticket)
        {
            var content = new StringContent(JsonSerializer.Serialize(ticket), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/cxone/tickets", content);
            return response.IsSuccessStatusCode;
        }

    }
}
