using System.Collections.Generic;
using MeusPedidos.Catalogo.Core.Application.Dtos;
using MeusPedidos.Catalogo.Core.Domain.Entidades;

namespace MeusPedidos.Catalogo.Core.Application.Mappers.Converter
{
    public static class CatalogoPromocaoConverter
    {
        public static CatalogoPromocaoDto ToDto(this CatalogoPromocao entity)
        {
            return AutoMapper.Mapper.Map<CatalogoPromocao, CatalogoPromocaoDto>(entity);
        }

        public static CatalogoPromocao ToEntity(this CatalogoPromocaoDto dto)
        {
            return AutoMapper.Mapper.Map<CatalogoPromocaoDto, CatalogoPromocao>(dto);
        }

        public static IEnumerable<CatalogoPromocaoDto> ToDtos(this IEnumerable<CatalogoPromocao> entities)
        {
            return entities != null ? AutoMapper.Mapper.Map<IEnumerable<CatalogoPromocao>, IEnumerable<CatalogoPromocaoDto>>(entities) : null;
        }

        public static IEnumerable<CatalogoPromocao> ToEntities(this IEnumerable<CatalogoPromocaoDto> dtos)
        {
            return dtos != null ? AutoMapper.Mapper.Map<IEnumerable<CatalogoPromocaoDto>, IEnumerable<CatalogoPromocao>>(dtos) : null;
        }
    }
}