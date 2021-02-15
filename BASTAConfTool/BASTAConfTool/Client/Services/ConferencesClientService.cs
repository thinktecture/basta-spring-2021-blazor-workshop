using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BASTAConfTool.Shared.DTO;

namespace BASTAConfTool.Client.Services
{
    public class ConferencesClientService
    {
        private HttpClient _httpClient;
        private string _conferencesUrl = "https://localhost:5001/api/conferences/";

        public ConferencesClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ConferenceOverview>> GetConferencesAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ConferenceOverview>>(_conferencesUrl);

            return result;
        }

        public async Task<ConferenceDetails> GetConferenceDetailsAsync(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<ConferenceDetails>(_conferencesUrl + id);

            return result;
        }

    }
}
