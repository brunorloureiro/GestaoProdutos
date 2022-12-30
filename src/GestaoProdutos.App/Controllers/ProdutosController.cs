using AutoMapper;
using GestaoProdutos.App.ViewModels;
using GestaoProdutos.Business.Intefaces;
using GestaoProdutos.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace GestaoProdutos.App.Controllers
{
    [Authorize]
    public class ProdutosController : BaseController
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoRepository produtoRepository, 
                                  IFornecedorRepository fornecedorRepository, 
                                  IMapper mapper, 
                                  IProdutoService produtoService,
                                  INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
            _produtoService = produtoService;
        }

        [AllowAnonymous]
        [Route("lista-de-produtos")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterProdutosFornecedores()));
        }

        [AllowAnonymous]
        [Route("lista-de-produtos/{codigo:int}")]
        public async Task<IActionResult> Index(int codigo)
        {
            return View(_mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterProdutosPorCodigo(codigo)));
        }

        [AllowAnonymous]
        [Route("dados-do-produto/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);

            if (produtoViewModel == null)
            {
                return NotFound();
            }

            return View(produtoViewModel);
        }

        [AllowAnonymous]
        [Route("novo-produto")]
        public async Task<IActionResult> Create()
        {
            var produtoViewModel = await PopularFornecedores(new ProdutoViewModel());

            return View(produtoViewModel);
        }

        [AllowAnonymous]
        [Route("novo-produto")]
        [HttpPost]
        public async Task<IActionResult> Create(ProdutoViewModel produtoViewModel)
        {
            produtoViewModel = await PopularFornecedores(produtoViewModel);
            if (!ModelState.IsValid) return View(produtoViewModel);

            await _produtoService.Adicionar(_mapper.Map<Produto>(produtoViewModel));

            if (!OperacaoValida()) return View(produtoViewModel);

            TempData["Sucesso"] = "Produto adicionado com sucesso!";

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [Route("editar-produto/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);

            if (produtoViewModel == null)
            {
                return NotFound();
            }

            return View(produtoViewModel);
        }

        [AllowAnonymous]
        [Route("editar-produto/{id:guid}")]
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id) return NotFound();

            var produtoAtualizacao = await ObterProduto(id);
            produtoViewModel.Fornecedor = produtoAtualizacao.Fornecedor;
            if (!ModelState.IsValid) return View(produtoViewModel);
                        
            produtoAtualizacao.Descricao = produtoViewModel.Descricao;
            produtoAtualizacao.DataValidade = produtoViewModel.DataValidade;
            produtoAtualizacao.DataFabricacao = produtoViewModel.DataFabricacao;
            produtoAtualizacao.Ativo = produtoViewModel.Ativo;
            produtoAtualizacao.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
            produtoAtualizacao.FornecedorId = produtoViewModel.FornecedorId;

            produtoAtualizacao.Fornecedor = _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedor(produtoViewModel.Id));

            await _produtoService.Atualizar(_mapper.Map<Produto>(produtoAtualizacao));

            if (!OperacaoValida()) return View(produtoViewModel);

            TempData["Sucesso"] = "Produto atualizado com sucesso!";

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [Route("excluir-produto/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var produto = await ObterProduto(id);

            if (!produto.Ativo)
            {
                TempData["Erro"] = "Produto já desativado!";
                return RedirectToAction("Index");
            }
            else
            {
                if (produto == null)
                {
                    return NotFound();
                }
            }

            return View(produto);
        }

        [AllowAnonymous]
        [Route("excluir-produto/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var produto = await ObterProduto(id);

            if (produto == null) return NotFound();

            await _produtoService.Desativar(_mapper.Map<Produto>(produto));

            if (!OperacaoValida()) return View(produto);

            TempData["Sucesso"] = "Produto desativado com sucesso!";

            return RedirectToAction("Index");
        }

        private async Task<ProdutoViewModel> ObterProduto(Guid id)
        {
            var produto = _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterProdutoFornecedor(id));
            produto.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
            return produto;
        }

        private async Task<ProdutoViewModel> PopularFornecedores(ProdutoViewModel produto)
        {
            produto.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
            return produto;
        }       
    }
}
