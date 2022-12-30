using System;
using System.Threading.Tasks;
using GestaoProdutos.Business.Models;

namespace GestaoProdutos.Business.Intefaces
{
    public interface IProdutoService : IDisposable
    {
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task Desativar(Produto produto);
        Task Remover(Guid id);
    }
}