using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuIngresso.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; } // Id de indentificaçao do cliente
        public string Nome { get; set; } 
        public string Senha { get; set; } 
        public string Email { get; set; } 
    }
}
