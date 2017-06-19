using AutoMapper;
using MeusPedidos.Catalogo.Core.Application.Dtos;
using MeusPedidos.Catalogo.Core.Domain.Entidades;

namespace MeusPedidos.Catalogo.Core.Application.Mappers.Profile
{
    public class PoliticaProfile : AutoMapper.Profile
    {
        public PoliticaProfile()
        {
            Register();
        }

        public void Register()
        {
            CreateMap<Politica, PoliticaDto>(MemberList.None).PreserveReferences();

            CreateMap<PoliticaDto, Politica>(MemberList.None);
        }
    }
}