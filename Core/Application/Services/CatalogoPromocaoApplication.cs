using System.Collections.Generic;
using System.Linq;
using MeusPedidos.Catalogo.Core.Domain.Entidades;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Application;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Repository;
using MeusPedidos.Catalogo.Core.Domain.Validacoes;

namespace MeusPedidos.Catalogo.Core.Application.Services
{
    public class CatalogoPromocaoApplication : ServiceBase<CatalogoPromocao>, ICatalogoPromocaoApplication
    {
        private readonly ICatalogoPromocaoRepository _catalogoPromocaoRepository;

        public CatalogoPromocaoApplication(ICatalogoPromocaoRepository repositoryBase) : base(repositoryBase)
        {
            _catalogoPromocaoRepository = repositoryBase;
        }

        public override ValidacaoResult ValidarEntidade(CatalogoPromocao entity)
        {
            return new ValidacaoResult();
        }

        public List<CatalogoPromocao> BuscarTodosCatalogoPromocao(string idcategoria)
        {
            return _catalogoPromocaoRepository.BuscarTodosCatalogoPromocao(idcategoria);
        }

        public double SomarTotalVendido(IEnumerable<ItensPedido> listacatalogopromocao)
        {
            return listacatalogopromocao.Where(x => x.QtdeVenda > 0).Sum(x => x.PrecoVenda);
        }

        public double SomarTotalVendido(IEnumerable<CatalogoPromocao> listacatalogopromocao)
        {
            return listacatalogopromocao.Sum(catalogoPromocao => catalogoPromocao.ItensPedidos.Where(x => x.QtdeVenda > 0).Sum(x => x.PrecoVenda));
        }

        public int SomarTotalItensVendidos(IEnumerable<ItensPedido> listacatalogopromocao)
        {
            return listacatalogopromocao.Where(x => x.QtdeVenda > 0).Sum(x => x.QtdeVenda);
        }

        public int SomarTotalItensVendidos(IEnumerable<CatalogoPromocao> listacatalogopromocao)
        {
            return listacatalogopromocao.Sum(catalogo => catalogo.ItensPedidos.Where(x => x.QtdeVenda > 0).Sum(x => x.QtdeVenda));
        }
    }
}