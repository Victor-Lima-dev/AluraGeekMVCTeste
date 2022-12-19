using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace AluraGeekMVCTeste.Models.Services
{
    public class ProdutosServices
    {
        //const string
        private readonly string apiEndpoint = "/produtos/";
        private readonly string apiEndpointBuscar = "/produtos/buscar/id/";
        private readonly string apiEndpointCadastrar = "/produtos/cadastrar";
        private readonly string apiEndpointEditar = "/Produtos/Editar/";
        private readonly string apiEndpointDeletar = "/Produtos/Deletar/";


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

        //metodo assincrono, lista todos os produtos
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

        //pega um produto pelo id
        public async Task<Produtos> GetProdutoAsync(int id)
        {
            
            
            var client = _clientFactory.CreateClient("AluraGeek");
            using (var response = await client.GetAsync(apiEndpointBuscar + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync())
                        produto = await JsonSerializer.DeserializeAsync<Produtos>(responseStream, _options);
                }
                else
                {
                    return (null);
                }

                return produto;
            }
        }

        //metodo para cadastrar um produto
        public async Task<Produtos> CreateProdutoAsync(Produtos produto)
        {
            var client = _clientFactory.CreateClient("AluraGeek");
            var produtoJson = new StringContent(JsonSerializer.Serialize(produto), Encoding.UTF8, "application/json");
            using (var response = await client.PostAsync(apiEndpointCadastrar, produtoJson))
            {
                if (response.IsSuccessStatusCode)
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync())
                        produto = await JsonSerializer.DeserializeAsync<Produtos>(responseStream, _options);
                    
                }
                else
                {
                    return (null);
                }
                return produto;

            }
        }

        //metodo para modificar um produto
        public async Task<Produtos> UpdateProdutoAsync(Produtos produto, int id)
        {
            var client = _clientFactory.CreateClient("AluraGeek");
            var produtoJson = new StringContent(JsonSerializer.Serialize(produto), Encoding.UTF8, "application/json");
            using (var response = await client.PutAsJsonAsync(apiEndpointEditar + id, produto))
            {
                if (response.IsSuccessStatusCode)
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync())
                        produto = await JsonSerializer.DeserializeAsync<Produtos>(responseStream, _options);
                }
                else
                {
                    return (null);
                }
                return produto;
            }
        }


        //metodo para deletar um produto
        public async Task<Produtos> DeleteAsync(int id)
        {
            var client = _clientFactory.CreateClient("AluraGeek");
            using (var response = await client.DeleteAsync(apiEndpointDeletar + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync())
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
