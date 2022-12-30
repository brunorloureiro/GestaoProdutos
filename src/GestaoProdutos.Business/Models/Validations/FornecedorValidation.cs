using GestaoProdutos.Business.Models.Validations.CNPJs;
using FluentValidation;

namespace GestaoProdutos.Business.Models.Validations
{
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(f => f.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.CNPJ.Length).NotEmpty().WithMessage("O campo {PropertyName} deve ser informado");
            RuleFor(f => f.CNPJ.Length).Equal(CnpjValidacao.TamanhoCnpj)
                .WithMessage("O campo CNPJ precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
            RuleFor(f => CnpjValidacao.Validar(f.CNPJ)).Equal(true)
                .WithMessage("O CNPJ fornecido é inválido.");
        }
    }
}