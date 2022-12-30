using AutoMapper;
using GestaoProdutos.App.ViewModels;
using GestaoProdutos.Business.Models;

namespace GestaoProdutos.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }
    }
}