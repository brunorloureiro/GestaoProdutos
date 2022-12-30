
using Bogus;
using Bogus.DataSets;
using GestaoProdutos.Business.Models;
using Bogus.Extensions.Brazil;
using System;
using Xunit;

namespace GestaoProdutos.Test.Fixture
{
    [CollectionDefinition(nameof(FornecedorCollection))]
    public class FornecedorCollection : ICollectionFixture<FornecedorTestsFixture> { };
    public class FornecedorTestsFixture : IDisposable
    {
        public Fornecedor GerarFornecedorValido()
        {
            var fornecedorFake = new Faker<Fornecedor>("pt_BR");
            fornecedorFake.RuleFor(forncedor => forncedor.Descricao, 
                                    (faker, forncedor) => faker.Company.CompanyName());
            fornecedorFake.RuleFor(forncedor => forncedor.CNPJ,
                                  (faker, forncedor) => faker.Company.Cnpj());
            fornecedorFake.RuleFor(forncedor => forncedor.Ativo, faker => faker
                                .Random.Bool(1));
            fornecedorFake.RuleFor(forncedor => forncedor.Codigo,
                                       (faker, forncedor) => faker.Random.Int(min: 1, max: 1000));

            return fornecedorFake;
        }

        public void Dispose(){}
    }
}
