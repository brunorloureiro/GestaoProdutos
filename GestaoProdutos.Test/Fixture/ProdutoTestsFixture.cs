
using Bogus;
using Bogus.DataSets;
using GestaoProdutos.Business.Models;
using System;
using Xunit;

namespace GestaoProdutos.Test.Fixture
{
    [CollectionDefinition(nameof(ProdutoCollection))]
    public class ProdutoCollection : ICollectionFixture<ProdutoTestsFixture> { };
    public class ProdutoTestsFixture : IDisposable
    {
        public Produto GerarProdutoValido()
        {
            var produtoFake = new Faker<Produto>("pt_BR");
            produtoFake.RuleFor(produto => produto.Descricao,
                                    (faker, produto) => faker.Commerce.ProductName());
            produtoFake.RuleFor(produto => produto.DataFabricacao,
                                  (faker, produto) => faker.Date.Recent());
            produtoFake.RuleFor(produto => produto.DataValidade,
                                 (faker, produto) => faker.Date.Between(DateTime.Now, DateTime.Now.AddYears(5)));
            produtoFake.RuleFor(produto => produto.Ativo, faker => faker
                                .Random.Bool(1));
            produtoFake.RuleFor(produto => produto.Codigo,
                                     (faker, produto) => faker.Random.Int(min: 1, max: 5000));
            produtoFake.RuleFor(produto => produto.FornecedorId,
                                   (faker, produto) => faker.Random.Guid());

            return produtoFake;
        }

        public void Dispose() { }
    }
}
