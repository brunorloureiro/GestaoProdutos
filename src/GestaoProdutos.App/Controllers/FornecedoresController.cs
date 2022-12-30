using AutoMapper;
using GestaoProdutos.App.ViewModels;
using GestaoProdutos.Business.Intefaces;
using GestaoProdutos.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoProdutos.App.Controllers
{
    [Authorize]
    public class FornecedoresController : BaseController
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IFornecedorService _fornecedorService;
        private readonly IMapper _mapper;

        public FornecedoresController(IFornecedorRepository fornecedorRepository, 
                                      IMapper mapper,
                                      IFornecedorService fornecedorService,
                                      INotificador notificador) : base(notificador)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
            _fornecedorService = fornecedorService;
        }

        [AllowAnonymous]
        [Route("lista-de-fornecedores")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos()));
        }

        [AllowAnonymous]
        [Route("lista-de-fornecedores/{codigo:int}")]
        public async Task<IActionResult> Index(int codigo)
        {
            var objeto = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterFornecedoresPorCodigo(codigo));
            return View(objeto);
        }

        [AllowAnonymous]
        [Route("dados-do-fornecedor/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var fornecedorViewModel = await ObterFornecedor(id);

            if (fornecedorViewModel == null)
            {
                return NotFound();
            }

            return View(fornecedorViewModel);
        }

        [AllowAnonymous]
        [Route("novo-fornecedor")]
        public IActionResult Create()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("novo-fornecedor")]
        [HttpPost]
        public async Task<IActionResult> Create(FornecedorViewModel fornecedorViewModel)
        {
            if (!ModelState.IsValid) return View(fornecedorViewModel);

            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
            await _fornecedorService.Adicionar(fornecedor);

            if (!OperacaoValida()) return View(fornecedorViewModel);

            TempData["Sucesso"] = "Fornecedor adicionado com sucesso!";

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [Route("editar-fornecedor/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var fornecedorViewModel = await ObterFornecedorProdutos(id);

            if (fornecedorViewModel == null)
            {
                return NotFound();
            }

            return View(fornecedorViewModel);
        }

        [AllowAnonymous]
        [Route("editar-fornecedor/{id:guid}")]
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, FornecedorViewModel fornecedorViewModel)
        {
            if (id != fornecedorViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(fornecedorViewModel);

            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
            await _fornecedorService.Atualizar(fornecedor);

            if (!OperacaoValida()) return View(await ObterFornecedorProdutos(id));

            TempData["Sucesso"] = "Fornecedor atualizado com sucesso!";

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [Route("excluir-fornecedor/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var fornecedorViewModel = await ObterFornecedor(id);

            if (!fornecedorViewModel.Ativo)
            {
                TempData["Erro"] = "Fornecedor já desativado!";
                return RedirectToAction("Index");
            }
            else
            {

                if (fornecedorViewModel == null)
                {
                    return NotFound();
                }
            }

            return View(fornecedorViewModel);
        }

        [AllowAnonymous]
        [Route("excluir-fornecedor/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var fornecedor = await ObterFornecedor(id);

            if (fornecedor == null) return NotFound();

            
            await _fornecedorService.Desativar(_mapper.Map<Fornecedor>(fornecedor));
            if (!OperacaoValida()) return View(fornecedor);
           
            return RedirectToAction("Index");
        }
               
        private async Task<FornecedorViewModel> ObterFornecedor(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedor(id));
        }

        private async Task<FornecedorViewModel> ObterFornecedorProdutos(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorProdutos(id));
        }
    }
}
