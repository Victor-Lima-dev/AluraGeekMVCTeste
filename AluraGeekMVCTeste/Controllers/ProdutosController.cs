using AluraGeekMVCTeste.Models;
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
        //metodo get assincrono, obter produto
        public async Task<IActionResult> Details(int id)
        {
            //obter produto
            var produto = await _produtosServices.GetProdutoAsync(id);
            //retornar view
            return View(produto);
        }

        //metodo get assincrono, criar um produto
        public IActionResult Create()
        {
            return View();
        }



        //metodo post assincrono, criar um produto
        [HttpPost]
        public async Task<IActionResult> Create(Produtos produto)
        {
            //verificar se o modelo é valido
            
                //criar produto
                await _produtosServices.CreateProdutoAsync(produto);
            //redirecionar para a pagina inicial

            return RedirectToAction(nameof(Index));
           
        }

        //metodo get assincrono, editar um produto
        public async Task<IActionResult> Edit(int id)
        {
            //obter produto
            var produto = await _produtosServices.GetProdutoAsync(id);
            //retornar view
            return View(produto);
        }



        //metodo put assincrono, edita um produto
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Produtos produto)
        {
            //verificar se o modelo é valido
            if (ModelState.IsValid)
            {
                //editar produto
                await _produtosServices.UpdateProdutoAsync(produto, id);
                //redirecionar para a pagina inicial
                return RedirectToAction(nameof(Index));
            }
            //retornar view
            return View(produto);
        }
        //metodo get assincrono, deletar um produto
        public async Task<IActionResult> Delete(int id)
        {
            //obter produto
            var produto = await _produtosServices.GetProdutoAsync(id);
            //retornar view
            return View(produto);
        }

        //metodo delete, deletar um produto
        [HttpPost, ActionName("Apagar")]
        public async Task<IActionResult> Delete(int id, Produtos produto)
        {
            //deletar produto
            await _produtosServices.DeleteAsync(produto.ProdutoId);
            //redirecionar para a pagina inicial
            return RedirectToAction(nameof(Index));
        }

    }
}
