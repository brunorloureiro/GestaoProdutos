using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestaoProdutos.Business.Models;

namespace GestaoProdutos.Business.Intefaces
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Task<Fornecedor> ObterFornecedor(Guid id);
        Task<Fornecedor> ObterFornecedorProdutos(Guid id);
        Task<IEnumerable<Fornecedor>> ObterFornecedoresPorCodigo(int codigo);
    }
}