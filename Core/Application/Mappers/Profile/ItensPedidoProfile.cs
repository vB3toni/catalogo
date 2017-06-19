using AutoMapper;
using MeusPedidos.Catalogo.Core.Application.Dtos;
using MeusPedidos.Catalogo.Core.Domain.Entidades;

namespace MeusPedidos.Catalogo.Core.Application.Mappers.Profile
{
    public class ItensPedidoProfile : AutoMapper.Profile
    {
        public ItensPedidoProfile()
        {
            Register();
        }

        public void Register()
        {
            CreateMap<ItensPedido, ItensPedidoDto>(MemberList.None).PreserveReferences();

            CreateMap<ItensPedidoDto, ItensPedido>(MemberList.None);
        }
    }
}