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
        public IActionResult Index()
        {
            using (ProdutoData data = new ProdutoData())
                return View(data.Read());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Produto produto)
        {

            if (!ModelState.IsValid)
            {
                return View(produto);
            }
            using (var data = new ProdutoData())
                data.Create(produto);
            return RedirectToAction("Index");
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
