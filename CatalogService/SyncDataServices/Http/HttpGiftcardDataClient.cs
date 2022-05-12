using System;
using CatalogService.Dtos;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CatalogService.SyncDataServices.Http
{
    public class HttpGiftcardDataClient : IGiftcardDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public HttpGiftcardDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _config = configuration;
        }


        public async Task SendPartnerToGidtcard(PartnerDto part)
        {
            try
            {
                var httpContent = new StringContent(
               JsonSerializer.Serialize(part),
               Encoding.UTF8,
               "application/json");

                var response = await _httpClient.PostAsync("https://localhost:49173/api/gs/partner", httpContent);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("--> Connected to Giftcard Service");
                }
                else
                {
                    Console.WriteLine("--> Not Connected to Giftcard Service");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
    }
}
