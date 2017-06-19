using System.Collections.Generic;
using MeusPedidos.Catalogo.Core.Application.Dtos;
using MeusPedidos.Catalogo.Core.Domain.Entidades;

namespace MeusPedidos.Catalogo.Core.Application.Mappers.Converter
{
    public static class PoliticaConverter
    {
        public static PoliticaDto ToDto(this Politica entity)
        {
            return AutoMapper.Mapper.Map<Politica, PoliticaDto>(entity);
        }

        public static Politica ToEntity(this PoliticaDto dto)
        {
            return AutoMapper.Mapper.Map<PoliticaDto, Politica>(dto);
        }

        public static IEnumerable<PoliticaDto> ToDtos(this IEnumerable<Politica> entities)
        {
            return entities != null ? AutoMapper.Mapper.Map<IEnumerable<Politica>, IEnumerable<PoliticaDto>>(entities) : null;
        }

        public static IEnumerable<Politica> ToEntities(this IEnumerable<PoliticaDto> dtos)
        {
            return dtos != null ? AutoMapper.Mapper.Map<IEnumerable<PoliticaDto>, IEnumerable<Politica>>(dtos) : null;
        }
    }
}