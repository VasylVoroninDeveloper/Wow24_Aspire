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

            var json = JsonSerializer.Serialize(ticket);
            Console.WriteLine($"Sending request to CxNone API: {_httpClient.BaseAddress + "TicketData"} with body: {json}");   

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/TicketData/SaveTicket", content);


            var responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Received response: {response.StatusCode} - {responseBody}");

            return response.IsSuccessStatusCode;
        }

    }
}
