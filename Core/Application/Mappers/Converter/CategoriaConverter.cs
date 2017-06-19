using System.Collections.Generic;
using MeusPedidos.Catalogo.Core.Application.Dtos;
using MeusPedidos.Catalogo.Core.Domain.Entidades;

namespace MeusPedidos.Catalogo.Core.Application.Mappers.Converter
{
    public static class CategoriaConverter
    {
        public static CategoriaDto ToDto(this Categoria entity)
        {
            return AutoMapper.Mapper.Map<Categoria, CategoriaDto>(entity);
        }

        public static Categoria ToEntity(this CategoriaDto dto)
        {
            return AutoMapper.Mapper.Map<CategoriaDto, Categoria>(dto);
        }

        public static IEnumerable<CategoriaDto> ToDtos(this IEnumerable<Categoria> entities)
        {
            return entities != null ? AutoMapper.Mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaDto>>(entities) : null;
        }

        public static IEnumerable<Categoria> ToEntities(this IEnumerable<CategoriaDto> dtos)
        {
            return dtos != null ? AutoMapper.Mapper.Map<IEnumerable<CategoriaDto>, IEnumerable<Categoria>>(dtos) : null;
        }
    }
}