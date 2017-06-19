using AutoMapper;
using MeusPedidos.Catalogo.Core.Application.Dtos;
using MeusPedidos.Catalogo.Core.Domain.Entidades;

namespace MeusPedidos.Catalogo.Core.Application.Mappers.Profile
{
    public class CatalogoPromocaoProfile : AutoMapper.Profile
    {
        public CatalogoPromocaoProfile()
        {
            Register();
        }

        public void Register()
        {
            CreateMap<CatalogoPromocao, CatalogoPromocaoDto>(MemberList.None).PreserveReferences();

            CreateMap<CatalogoPromocaoDto, CatalogoPromocao>(MemberList.None);
        }
    }
}