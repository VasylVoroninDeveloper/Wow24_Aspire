using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client.Clients
{
    internal class CrmApiClient
    {

        private readonly HttpClient _httpClient;

        public CrmApiClient(string url)
        {
            _httpClient = new HttpClient() { BaseAddress = new Uri(url) };
        }

        public async Task<List<CrmTicket>> GetTicketsAsync()
        {
            var response = await _httpClient.GetAsync("/TicketData/GetTickets");

            var responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Received response: {response.StatusCode} - {responseBody}");

            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<List<CrmTicket>>(responseBody, jsonOptions) ?? new List<CrmTicket>();
        }

    }
}
