using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestaoProdutos.Business.Models;

namespace GestaoProdutos.Business.Intefaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId);
        Task<IEnumerable<Produto>> ObterProdutosFornecedores();
        Task<Produto> ObterProdutoFornecedor(Guid id);
        Task<List<Produto>> ObterProdutosPorCodigo(int codigo);
    }
}