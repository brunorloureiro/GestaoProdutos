using System;
using System.Collections.Generic;


namespace GestaoProdutos.Business.Models
{
    public class Fornecedor : Entity
    {
        public string Descricao { get; set; }
        public string CNPJ { get; set; }

        /* EF Relations */
        public IEnumerable<Produto> Produtos { get; set; }
    }
}