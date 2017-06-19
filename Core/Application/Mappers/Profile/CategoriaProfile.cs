using AutoMapper;
using MeusPedidos.Catalogo.Core.Application.Dtos;
using MeusPedidos.Catalogo.Core.Domain.Entidades;

namespace MeusPedidos.Catalogo.Core.Application.Mappers.Profile
{
    public class CategoriaProfile : AutoMapper.Profile
    {
        public CategoriaProfile()
        {
            Register();
        }

        public void Register()
        {
            CreateMap<Categoria, CategoriaDto>(MemberList.None).PreserveReferences();

            CreateMap<CategoriaDto, Categoria>(MemberList.None);
        }
    }
}