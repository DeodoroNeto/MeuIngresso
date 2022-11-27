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
    public class ClienteController : Controller
    {
        [HttpGet]
        public IActionResult Index(Cliente novoCliente)
        {
            return View(novoCliente);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(IFormCollection cliente)
        {
            string nome = cliente["nome"];
            string email = cliente["email"];
            string senha = cliente["senha"];
            if(nome.Length < 3)
            {
                ViewBag.Mensagem = "Nome deve conter 6 ou mais caracters";
                return View();
            }
            if(!email.Contains('@'))
            {
                ViewBag.Mensagem = "Email inválido";
                return View();
            }
            if(senha.Length < 6)
            {
                ViewBag.Mensagem = "Senha deve conter mais de 3 digitos";
            }
            var novoCliente = new Cliente();
            novoCliente.Nome = cliente["nome"];
            novoCliente.Email = cliente["email"];
            novoCliente.Senha = cliente["senha"];

            using (ClienteData data = new ClienteData())
                data.Create(novoCliente);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Read(IFormCollection cliente)
        {
            string nome = cliente["nome"];
            string email = cliente["email"];
            string senha = cliente["senha"];

            if (!email.Equals(""))
            {
                Cliente cli = new Cliente();
                cli.Nome = cliente["nome"];
                cli.Nome = cliente["nome"];
                cli.Nome = cliente["nome"];

                Cliente c = new Cliente();
                using (ClienteData data = new ClienteData())
                    c = data.Read(cli.Email);
                if (c.Senha == cli.Senha)
                {
                    ViewBag.Mensagem = "Olá";
                    return View("Index", c);
                }
                else
                {
                    ViewBag.Mensagem = "Usuário ou senha inválido";
                    return View("Index", null);
                }
            }
            return View("Create");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using (ClienteData data = new ClienteData())
                return View(data.Read(id));
        }

        [HttpPost]
        public IActionResult Update(int id, Cliente cliente)
        {
            cliente.IdCliente = id;
            return View(cliente);

            using (ClienteData data = new ClienteData())
            {
                data.Update(cliente);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            using (ClienteData data = new ClienteData())
                data.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
