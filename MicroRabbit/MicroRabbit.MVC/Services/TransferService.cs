using MicroRabbit.MVC.Models.DTO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace MicroRabbit.MVC.Services
{
    public class TransferService : ITransferService
    {
        private readonly HttpClient _httpClient;

        public TransferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Transfer(TransferDTO transferDTO)
        {
            var uri = "Https://localhost:5001/Banking";
            var transferContent = new StringContent(JsonConvert.SerializeObject(transferDTO),System.Text.Encoding.UTF8, "application/json");    
            var response = await _httpClient.PostAsync(uri, transferContent);   
            response.EnsureSuccessStatusCode();
        }
    }
}
