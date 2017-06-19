using System.Collections.Generic;
using MeusPedidos.Catalogo.Core.Application.Dtos;
using MeusPedidos.Catalogo.Core.Domain.Entidades;

namespace MeusPedidos.Catalogo.Core.Application.Mappers.Converter
{
    public static class PromocaoConverter
    {
        public static PromocaoDto ToDto(this Promocao entity)
        {
            return AutoMapper.Mapper.Map<Promocao, PromocaoDto>(entity);
        }

        public static Promocao ToEntity(this PromocaoDto dto)
        {
            return AutoMapper.Mapper.Map<PromocaoDto, Promocao>(dto);
        }

        public static IEnumerable<PromocaoDto> ToDtos(this IEnumerable<Promocao> entities)
        {
            return entities != null ? AutoMapper.Mapper.Map<IEnumerable<Promocao>, IEnumerable<PromocaoDto>>(entities) : null;
        }

        public static IEnumerable<Promocao> ToEntities(this IEnumerable<PromocaoDto> dtos)
        {
            return dtos != null ? AutoMapper.Mapper.Map<IEnumerable<PromocaoDto>, IEnumerable<Promocao>>(dtos) : null;
        }
    }
}