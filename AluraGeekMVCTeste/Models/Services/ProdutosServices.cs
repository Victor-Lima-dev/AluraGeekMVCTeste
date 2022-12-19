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
        private Produtos produto;
        //enurable produtos
        private IEnumerable<Produtos> produtos;


        public ProdutosServices(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        //metodo assincrono
        public async Task<IEnumerable<Produtos>> GetProdutosAsync()
        {
            //criar cliente
            var client = _clientFactory.CreateClient("AluraGeek");
            //obter resposta

            using (var response = await client.GetAsync(apiEndpoint))
            {
                //verificar se a resposta foi bem sucedida
                if (response.IsSuccessStatusCode)
                {
                    //obter conteudo
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    //deserializar
                     produtos = await JsonSerializer.DeserializeAsync<IEnumerable<Produtos>>(responseStream, _options);
                    
                }
                else
                {
                    return (null);
                }

                return produtos;
            }
        }

        public async Task<Produtos> GetProdutoAsync(int id)
        {
            var client = _clientFactory.CreateClient("AluraGeek");
            using (var response = await client.GetAsync(apiEndpoint + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    produto = await JsonSerializer.DeserializeAsync<Produtos>(responseStream, _options);
                }
                else
                {
                    return (null);
                }

                return produto;
            }
        }


    }
}
