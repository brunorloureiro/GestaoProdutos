using FluentValidation;

namespace GestaoProdutos.Business.Models.Validations
{
    public class ProdutoValidation : AbstractValidator<Produto>
    {
        public ProdutoValidation()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.DataFabricacao)
                .NotEmpty().WithMessage("O campo Data Fabricação precisa ser informado")
                .LessThan(c => c.DataValidade).WithMessage("O campo Data Fabricação não pode ser maior do que a Data Validade");

            RuleFor(c => c.DataValidade)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser informado");

            RuleFor(c => c.FornecedorId)
                .NotEmpty()
                .WithMessage("O campo Fornecedor precisa ser informado");
        }
    }
}