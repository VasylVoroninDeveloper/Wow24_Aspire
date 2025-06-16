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

        public CrmApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CrmTicket>> GetTicketsAsync()
        {
            var response = await _httpClient.GetAsync("/api/tickets");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<List<CrmTicket>>(json, jsonOptions) ?? new List<CrmTicket>();
        }

    }
}
