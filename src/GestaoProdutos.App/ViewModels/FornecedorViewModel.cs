using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoProdutos.App.ViewModels
{
    public class FornecedorViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Código")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string CNPJ { get; set; }

        
        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}