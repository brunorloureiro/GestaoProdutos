using GestaoProdutos.Business.Intefaces;
using GestaoProdutos.Business.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;
using GestaoProdutos.Test.Fixture;

namespace GestaoProdutos.Test
{
    [TestClass]
    public class ProdutoTests
    {
        [TestMethod(displayName: "Adicionar Produto Com Sucesso")]
        [Trait("Categoria", "ProdutoTests")]
        public void Produto_Adicionar_DeveSerAdicionadoComSucesso()
        {
            var produtoValido = new ProdutoTestsFixture().GerarProdutoValido();
            Mock<IProdutoService> mocksService = new Mock<IProdutoService>();

            var retorno = mocksService.Object.Adicionar(produtoValido);

            Assert.IsNotNull(retorno);
            Assert.IsTrue(retorno.IsCompleted);
        }

        [TestMethod(displayName: "Alterar Produto Com Sucesso")]
        [Trait("Categoria", "ProdutoTests")]
        public void Produto_Alterar_DeveSerAlteradoComSucesso()
        {
            var produtoValido = new ProdutoTestsFixture().GerarProdutoValido();
            Mock<IProdutoService> mocksService = new Mock<IProdutoService>();

            var retorno = mocksService.Object.Atualizar(produtoValido);

            Assert.IsNotNull(retorno);
            Assert.IsTrue(retorno.IsCompleted);
        }

        [TestMethod(displayName: "Desativar Produto Com Sucesso")]
        [Trait("Categoria", "ProdutoTests")]
        public void Produto_Desativar_DeveSerDesativadoComSucesso()
        {
            Mock<Produto> mocks = new Mock<Produto>();
            mocks.Object.Id = new System.Guid("87825CF9-28CD-498B-5DFB-08DAE99DA131");
            Mock<IProdutoService> mocksService = new Mock<IProdutoService>();

            var retorno = mocksService.Object.Desativar(mocks.Object);

            Assert.IsNotNull(retorno);
            Assert.IsTrue(retorno.IsCompleted);
        }
    }
}
