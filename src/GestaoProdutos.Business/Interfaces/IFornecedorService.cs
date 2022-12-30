using System;
using System.Threading.Tasks;
using GestaoProdutos.Business.Models;

namespace GestaoProdutos.Business.Intefaces
{
    public interface IFornecedorService : IDisposable
    {
        Task Adicionar(Fornecedor fornecedor);
        Task Atualizar(Fornecedor fornecedor);
        Task Desativar(Fornecedor fornecedor);
        Task Remover(Guid id);
    }
}