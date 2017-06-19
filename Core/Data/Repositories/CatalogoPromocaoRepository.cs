using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeusPedidos.Catalogo.Core.Domain.Entidades;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Repository;

namespace MeusPedidos.Catalogo.Core.Data.Repositories
{
    public class CatalogoPromocaoRepository : RepositoryBase<CatalogoPromocao>, ICatalogoPromocaoRepository
    {
        public CatalogoPromocaoRepository() : base(false)
        {
        }

        public List<CatalogoPromocao> BuscarTodosCatalogoPromocao(string idcategoria)
        {
            try
            {
                var listacatalogo = new List<CatalogoPromocao>();

                var listapromocoes = SqliteConnection.Table<Promocao>();

                foreach (var promocao in listapromocoes.Where(x => idcategoria == null || x.IdCategoria == idcategoria || idcategoria == "0"))
                {
                    var listaprodutos = SqliteConnection.Table<Produto>().Where(x => x.IdCategoria == promocao.IdCategoria);

                    var listaitenspedido = new List<ItensPedido>();

                    listaitenspedido.AddRange(listaprodutos.Select(x => new ItensPedido
                    {
                        NomeProduto = x.Nome,
                        QtdeVenda = 0,
                        PrecoBruto = x.Preco,
                        Desconto = 0,
                        FotoProduto = x.Foto,
                        Favorito = x.Favorito,
                        IdProduto = x.IdProduto,
                        Produto = x

                    }).ToList());

                    if (listaitenspedido.Count > 0)
                    {
                        listacatalogo.Add(new CatalogoPromocao
                        {
                            IdPromocao = promocao.IdPromocao,
                            DescricaoPromocao = promocao.Descricao,
                            ItensPedidos = listaitenspedido,
                            IdCategoria = promocao.IdCategoria
                        });
                    }
                }

                return listacatalogo;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}