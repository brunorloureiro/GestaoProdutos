using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestaoProdutos.Business.Intefaces;
using GestaoProdutos.Business.Models;
using GestaoProdutos.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoProdutos.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(MeuDbContext context) : base(context)
        {
        }

        public async Task<Fornecedor> ObterFornecedor(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }
   
        public async Task<Fornecedor> ObterFornecedorProdutos(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                .Include(c => c.Produtos)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Fornecedor>> ObterFornecedoresPorCodigo(int codigo)
        {
            return await Buscar(p => p.Codigo == codigo);
        }
    }
}