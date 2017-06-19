using AutoMapper;
using MeusPedidos.Catalogo.Core.Application.Dtos;
using MeusPedidos.Catalogo.Core.Domain.Entidades;

namespace MeusPedidos.Catalogo.Core.Application.Mappers.Profile
{
    public class ProdutoProfile : AutoMapper.Profile
    {
        public ProdutoProfile()
        {
            Register();
        }

        public void Register()
        {
            CreateMap<Produto, ProdutoDto>(MemberList.None).PreserveReferences();

            CreateMap<ProdutoDto, Produto>(MemberList.None);
        }
    }
}