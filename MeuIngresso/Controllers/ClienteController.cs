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
            if (nome.Length < 3)
            {
                ViewBag.Mensagem = "Nome deve conter 6 ou mais caracters";
                return View();
            }
            if (!email.Contains('@'))
            {
                ViewBag.Mensagem = "Email inválido";
                return View();
            }
            if (senha.Length < 6)
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

            Cliente ClienteLogando = new Cliente();
            ClienteLogando.Email = cliente["email"];
            ClienteLogando.Senha = cliente["senha"];

            if (ClienteLogando.Email.Equals(""))
            {
                ViewBag.Mensagem = "Campo Email não pode ser vazio!";
                return View("Index", null);
            }

            if (ClienteLogando.Senha.Equals(""))
            {
                ViewBag.Mensagem = "Campo Senha não pode ser vazio!";
                return View("Index", null);
            }

            Cliente senhaCliente = new Cliente();
            using (ClienteData senhaData = new ClienteData())
                senhaCliente = senhaData.Read(ClienteLogando.Email);

            if (ClienteLogando.Senha == senhaCliente.Senha) //Ocorre uma exeption, ao tentar fazer loguin sem estar cadastrado no banco
            {
                Cliente cli = new Cliente();
                cli.Nome = cliente["nome"];
                cli.Email = cliente["email"];
                cli.Senha = cliente["senha"];

                Cliente c = new Cliente();
                using (ClienteData data = new ClienteData())
                    c = data.Read(cli.Email);

                ViewBag.Mensagem = "Olá";
                return View("Index", c);
            }
            ViewBag.Mensagem = "Senha inválida";
            return View("Index", null);
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
            View(cliente);

            using (ClienteData data = new ClienteData())
                data.Update(cliente);
            return RedirectToAction("Index", cliente);
        }

        public IActionResult Delete(int id)
        {
            using (ClienteData data = new ClienteData())
                data.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
