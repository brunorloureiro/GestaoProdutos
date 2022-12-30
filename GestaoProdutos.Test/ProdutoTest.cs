using GestaoProdutos.Business.Intefaces;
using GestaoProdutos.Business.Models;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GestaoProdutos.Test
{
    [TestClass]
    public class ProdutoTest
    {
        public ProdutoTest()
        {
        }

        [TestMethod]
        public void TestInclude()
        {
            Mock<Produto> mocks = new Mock<Produto>();
            mocks.Object.Descricao = "Teste Produto";
            mocks.Object.DataFabricacao = DateTime.Now.AddYears(-5);
            mocks.Object.DataValidade = DateTime.Now.AddYears(3);
            mocks.Object.Ativo = true;
            mocks.Object.FornecedorId = new System.Guid("87825CF9-28CD-498B-5DFB-08DAE99DA131");

            Mock<IProdutoService> mocksService = new Mock<IProdutoService>();

            var retorno = mocksService.Object.Adicionar(mocks.Object);

            Assert.IsNotNull(retorno);
            Assert.IsTrue(retorno.IsCompleted);
        }

        [TestMethod]
        public void TestAlter()
        {
            Mock<Produto> mocks = new Mock<Produto>();
            mocks.Object.Id = new System.Guid("61CBADB2-FB28-401D-A0AC-08DAE9AE016F");
            mocks.Object.Descricao = "Teste Produto";
            mocks.Object.DataFabricacao = DateTime.Now.AddYears(-5);
            mocks.Object.DataValidade = DateTime.Now.AddYears(3);
            mocks.Object.Ativo = true;
            mocks.Object.FornecedorId = new System.Guid("87825CF9-28CD-498B-5DFB-08DAE99DA131");

            Mock<IProdutoService> mocksService = new Mock<IProdutoService>();

            var retorno = mocksService.Object.Atualizar(mocks.Object);

            Assert.IsNotNull(retorno);
            Assert.IsTrue(retorno.IsCompleted);
        }

        [TestMethod]
        public void TestDelete()
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
