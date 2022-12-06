using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MeuIngresso.Data;
using MeuIngresso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuIngresso.Controllers
{
    public class ProdutoController : Controller
    {
        [HttpGet]
        public IActionResult Index(List<Produto> produtos)
        {
            using (ProdutoData produtoData = new ProdutoData())
                produtos = produtoData.Read();
            ViewBag.Mensagem = "Produtos Cadastrados";
            
            return View("Index", produtos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(IFormCollection produto)
        {

            Produto novoProduto = new Produto();
            novoProduto.Nome = produto["nome"];
            novoProduto.Descricao = produto["descricao"];
            novoProduto.Valor = produto["valor"];
            novoProduto.TipoDeShow = produto["tipo_De_Show"];

            using (ProdutoData data = new ProdutoData())
                data.Create(novoProduto);
            return RedirectToAction("Index", "Produto");
        }

        [HttpPost]
        public IActionResult Read(List<Produto> produtos)
        {
            using (ProdutoData produtoData = new ProdutoData())
                produtos = produtoData.Read();
            ViewBag.Mensagem = "Produtos Cadastrados";

            return View("Index", produtos);
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            using (ProdutoData data = new ProdutoData())
                return View(data.Read(id));
        }
        [HttpPost]
        public IActionResult Update(int id, Produto produto) 
        {
            produto.IdProduto = id;
            View(produto);

            using (ProdutoData data = new ProdutoData())
                data.Update(produto);
            return RedirectToAction("Index", produto);
        }
        public IActionResult Delete(int id)
        {
            using (ProdutoData data = new ProdutoData())
                data.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
