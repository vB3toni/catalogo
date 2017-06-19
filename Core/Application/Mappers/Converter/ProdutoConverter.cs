using System.Collections.Generic;
using MeusPedidos.Catalogo.Core.Application.Dtos;
using MeusPedidos.Catalogo.Core.Domain.Entidades;

namespace MeusPedidos.Catalogo.Core.Application.Mappers.Converter
{
    public static class ProdutoConverter
    {
        public static ProdutoDto ToDto(this Produto entity)
        {
            return AutoMapper.Mapper.Map<Produto, ProdutoDto>(entity);
        }

        public static Produto ToEntity(this ProdutoDto dto)
        {
            return AutoMapper.Mapper.Map<ProdutoDto, Produto>(dto);
        }

        public static IEnumerable<ProdutoDto> ToDtos(this IEnumerable<Produto> entities)
        {
            return entities != null ? AutoMapper.Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoDto>>(entities) : null;
        }

        public static IEnumerable<Produto> ToEntities(this IEnumerable<ProdutoDto> dtos)
        {
            return dtos != null ? AutoMapper.Mapper.Map<IEnumerable<ProdutoDto>, IEnumerable<Produto>>(dtos) : null;
        }
    }
}