using AluraGeekMVCTeste.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace AluraGeekMVCTeste.Controllers
{
    public class ProdutosController : Controller
    {
        //produtos services
        private readonly ProdutosServices _produtosServices;

        //construtor
        public ProdutosController(ProdutosServices produtosServices)
        {
            _produtosServices = produtosServices;
        }

        //metodo get assincrono, listar produtos
        public async Task<IActionResult> Index()
        {
            //obter produtos
            var produtos = await _produtosServices.GetProdutosAsync();
            //retornar view
            return View(produtos);
        }




    }
}
