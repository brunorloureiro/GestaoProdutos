using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoProdutos.App.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        
        [DisplayName("Código")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Data Fabricação")]
        public DateTime DataFabricacao { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Data Validade")]
        public DateTime DataValidade { get; set; }
 
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Fornecedor")]
        public Guid FornecedorId { get; set; }


        public FornecedorViewModel Fornecedor { get; set; }

        public IEnumerable<FornecedorViewModel> Fornecedores { get; set; }
    }
}