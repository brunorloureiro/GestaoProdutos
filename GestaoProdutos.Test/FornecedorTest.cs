using GestaoProdutos.Business.Intefaces;
using GestaoProdutos.Business.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GestaoProdutos.Test
{
    [TestClass]
    public class FornecedorTest
    {
        public FornecedorTest()
        {
        }

        [TestMethod]
        public void TestInclude()
        {
            Mock<Fornecedor> mocks = new Mock<Fornecedor>();
            mocks.Object.Descricao = "Teste Fornecedor";
            mocks.Object.CNPJ = "11734963000135";
            mocks.Object.Ativo = true;

            Mock<IFornecedorService> mocksService = new Mock<IFornecedorService>();

            var retorno = mocksService.Object.Adicionar(mocks.Object);

            Assert.IsNotNull(retorno);
            Assert.IsTrue(retorno.IsCompleted);
        }

        
        [TestMethod]
        public void TestAlter()
        {
            Mock<Fornecedor> mocks = new Mock<Fornecedor>();
            mocks.Object.Id = new System.Guid("87825CF9-28CD-498B-5DFB-08DAE99DA131");
            mocks.Object.Descricao = "Teste Fornecedor";
            mocks.Object.CNPJ = "11734963000135";
            mocks.Object.Ativo = true;

            Mock<IFornecedorService> mocksService = new Mock<IFornecedorService>();

            var retorno = mocksService.Object.Atualizar(mocks.Object);

            Assert.IsNotNull(retorno);
            Assert.IsTrue(retorno.IsCompleted);
        }

        [TestMethod]
        public void TestDelete()
        {
            Mock<Fornecedor> mocks = new Mock<Fornecedor>();
            mocks.Object.Id = new System.Guid("87825CF9-28CD-498B-5DFB-08DAE99DA131");
        
            Mock<IFornecedorService> mocksService = new Mock<IFornecedorService>();

            var retorno = mocksService.Object.Desativar(mocks.Object);

            Assert.IsNotNull(retorno);
            Assert.IsTrue(retorno.IsCompleted);
        }
    }
}
