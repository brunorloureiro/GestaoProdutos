using GestaoProdutos.Business.Intefaces;
using GestaoProdutos.Business.Models;
using GestaoProdutos.Test.Fixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;

namespace GestaoProdutos.Test
{
    [CollectionDefinition(nameof(FornecedorCollection))]
    [TestClass]
    public class FornecedorTests
    {
        public FornecedorTests()
        {}

        [TestMethod(displayName:"Adicionar Fornecedor Com Sucesso")]
        [Trait("Categoria", "FornecedorTests")]
        public void Fornecedor_Adicionar_DeveSerAdicionadoComSucesso()
        {
            //Arrange
            var fornecedorValido = new FornecedorTestsFixture().GerarFornecedorValido();
            Mock<IFornecedorService> mocksService = new Mock<IFornecedorService>();
            //Act
            var retorno = mocksService.Object.Adicionar(fornecedorValido);
            //Assert
            Assert.IsNotNull(retorno);
            Assert.IsTrue(retorno.IsCompleted);
        }

        
        [TestMethod(displayName: "Alterar Fornecedor Com Sucesso")]
        [Trait("Categoria", "FornecedorTest")]
        public void Fornecedor_Alterar_DeveSerAlteradoComSucesso()
        {
            //Arrange
            var fornecedorValido = new FornecedorTestsFixture().GerarFornecedorValido();
            Mock<IFornecedorService> mocksService = new Mock<IFornecedorService>();
            
            //Act
            var retorno = mocksService.Object.Atualizar(fornecedorValido);
            //Assert
            Assert.IsNotNull(retorno);
            Assert.IsTrue(retorno.IsCompleted);
        }

        [TestMethod(displayName: "Desativar Fornecedor Com Sucesso")]
        [Trait("Categoria", "FornecedorTest")]
        public void Fornecedor_Desativar_DeveSerDesativoComSucesso()
        {
            //Arrange
            Mock<Fornecedor> mocks = new Mock<Fornecedor>();
            mocks.Object.Id = new System.Guid("87825CF9-28CD-498B-5DFB-08DAE99DA131");
            Mock<IFornecedorService> mocksService = new Mock<IFornecedorService>();
            //Act
            var retorno = mocksService.Object.Desativar(mocks.Object);
            //Assert
            Assert.IsNotNull(retorno);
            Assert.IsTrue(retorno.IsCompleted);
        }
    }
}
