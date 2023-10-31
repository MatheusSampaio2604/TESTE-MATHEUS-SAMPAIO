
using TESTE_MATHEUS_SAMPAIO.Models;
using AutoMapper;

namespace TESTE_MATHEUS_SAMPAIO.Context.DTO.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProdutosModel, ProdutosViewModel>().ReverseMap();

            CreateMap<ServicosModel, ServicosViewModel>().ReverseMap();

            CreateMap<UsuariosModel, UsuariosViewModel>().ReverseMap();

            CreateMap<FornecedoresModel, FornecedoresViewModel>().ReverseMap();

            CreateMap<DepartamentosModel, DepartamentosViewModel>().ReverseMap();
            
            CreateMap<SolicitaComprasModel, SolicitaComprasViewModel>().ReverseMap();
            
            CreateMap<SolicitaServicosModel, SolicitaServicosViewModel>().ReverseMap();

            

        }
    }
}