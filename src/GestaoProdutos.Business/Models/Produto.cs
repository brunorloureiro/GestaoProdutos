using System;

namespace GestaoProdutos.Business.Models
{
    public class Produto : Entity
    {
        public string Descricao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public Guid FornecedorId { get; set; }


        /* EF Relations */
        public Fornecedor Fornecedor { get; set; }
    }
}