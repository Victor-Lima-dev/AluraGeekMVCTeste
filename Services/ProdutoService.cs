using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AluraGeekMVCTeste.Models;
using Microsoft.AspNetCore.Mvc;


namespace AluraGeekMVCTeste.Services
{
    public class ProdutoService
    {
        private const string apiEndpoint = "/produtos";
        private readonly JsonSerializerOptions _options;
        private readonly HttpClientFactory _httpClient;
        //construtor
        public ProdutoService(HttpClientFactory httpClient)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }
       
    }
}
