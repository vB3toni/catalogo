using AutoMapper;
using MeusPedidos.Catalogo.Core.Application.Dtos;
using MeusPedidos.Catalogo.Core.Domain.Entidades;

namespace MeusPedidos.Catalogo.Core.Application.Mappers.Profile
{
    public class PromocaoProfile : AutoMapper.Profile
    {
        public PromocaoProfile()
        {
            Register();
        }

        public void Register()
        {
            CreateMap<Promocao, PromocaoDto>(MemberList.None).PreserveReferences();

            CreateMap<PromocaoDto, Promocao>(MemberList.None);
        }
    }
}