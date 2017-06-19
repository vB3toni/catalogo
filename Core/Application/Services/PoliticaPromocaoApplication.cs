using System.Collections.Generic;
using System.Linq;
using MeusPedidos.Catalogo.Core.Domain.Entidades;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Application;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Repository;
using MeusPedidos.Catalogo.Core.Domain.Validacoes;

namespace MeusPedidos.Catalogo.Core.Application.Services
{
    public class PoliticaPromocaoApplication : ServiceBase<Politica>, IPoliticaApplication
    {
        public PoliticaPromocaoApplication(IPoliticaRepository repositoryBase) : base(repositoryBase)
        {
        }

        public override ValidacaoResult ValidarEntidade(Politica entity)
        {
            return new ValidacaoResult();
        }

        public Politica BuscarValorDescontoPoliticaPromocao(List<Politica> politicapromocao, List<CatalogoPromocao> promocoes, string idcategoriaitem)
        {
            foreach (var promocao in promocoes.Where(x => x.IdCategoria.Equals(idcategoriaitem)))
            {
                var politica = politicapromocao.Where(x => x.IdPromocao.Equals(promocao.IdPromocao));
                
                var somaitens = promocao.ItensPedidos.Where(x => x.QtdeVenda > 0).Sum(x => x.QtdeVenda);

                foreach (var politicadesconto in politica.OrderByDescending(x => x.QtdeMinima))
                {
                    if (politicadesconto.QtdeMinima <= somaitens)
                    {
                        return politicadesconto;
                    }
                }
            }
            return null;
        }
    }
}