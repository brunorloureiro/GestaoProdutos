using System;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Business.Intefaces;
using GestaoProdutos.Business.Models;
using GestaoProdutos.Business.Models.Validations;

namespace GestaoProdutos.Business.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository, 
                                 INotificador notificador) : base(notificador)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task Adicionar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)) return;

            if (_fornecedorRepository.Buscar(f => f.CNPJ == fornecedor.CNPJ).Result.Any())
            {
                Notificar("Já existe um fornecedor com este CNPJ infomado.");
                return;
            }

            await _fornecedorRepository.Adicionar(fornecedor);
        }

        public async Task Atualizar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)) return;

            if (_fornecedorRepository.Buscar(f => f.CNPJ == fornecedor.CNPJ && f.Id != fornecedor.Id).Result.Any())
            {
                Notificar("Já existe um fornecedor com este CNPJ infomado.");
                return;
            }

            await _fornecedorRepository.Atualizar(fornecedor);
        }

        public async Task Desativar(Fornecedor fornecedor)
        {
            await _fornecedorRepository.Desativar(fornecedor);
        }

        public async Task Remover(Guid id)
        {
            if (_fornecedorRepository.ObterFornecedorProdutos(id).Result.Produtos.Any())
            {
                Notificar("O fornecedor possui produtos cadastrados!");
                return;
            }

            await _fornecedorRepository.Remover(id);
        }

        public void Dispose()
        {
            _fornecedorRepository?.Dispose();
        }
    }
}