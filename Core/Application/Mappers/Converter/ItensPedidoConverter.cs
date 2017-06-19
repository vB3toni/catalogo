using System.Collections.Generic;
using MeusPedidos.Catalogo.Core.Application.Dtos;
using MeusPedidos.Catalogo.Core.Domain.Entidades;

namespace MeusPedidos.Catalogo.Core.Application.Mappers.Converter
{
    public static class ItensPedidoConverter
    {
        public static ItensPedidoDto ToDto(this ItensPedido entity)
        {
            return AutoMapper.Mapper.Map<ItensPedido, ItensPedidoDto>(entity);
        }

        public static ItensPedido ToEntity(this ItensPedidoDto dto)
        {
            return AutoMapper.Mapper.Map<ItensPedidoDto, ItensPedido>(dto);
        }

        public static IEnumerable<ItensPedidoDto> ToDtos(this IEnumerable<ItensPedido> entities)
        {
            return entities != null ? AutoMapper.Mapper.Map<IEnumerable<ItensPedido>, IEnumerable<ItensPedidoDto>>(entities) : null;
        }

        public static IEnumerable<ItensPedido> ToEntities(this IEnumerable<ItensPedidoDto> dtos)
        {
            return dtos != null ? AutoMapper.Mapper.Map<IEnumerable<ItensPedidoDto>, IEnumerable<ItensPedido>>(dtos) : null;
        }
    }
}