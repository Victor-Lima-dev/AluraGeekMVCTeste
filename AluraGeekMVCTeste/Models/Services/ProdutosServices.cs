using System.Text.Json;

namespace AluraGeekMVCTeste.Models.Services
{
    public class ProdutosServices
    {
        //const string
        private readonly string apiEndpoint = "/produtos/";

        private readonly JsonSerializerOptions _options;

        //httpclientFactory
        private readonly IHttpClientFactory _clientFactory;
        private Produtos produtos;
        
        public ProdutosServices(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }




    }
}
