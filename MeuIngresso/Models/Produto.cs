﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuIngresso.Models
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
    }
}
