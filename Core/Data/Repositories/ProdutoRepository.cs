using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MeusPedidos.Catalogo.Core.Data.Configuration.Json;
using MeusPedidos.Catalogo.Core.Domain.Entidades;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Repository;
using Newtonsoft.Json;

namespace MeusPedidos.Catalogo.Core.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository() : base(true)
        {
        }

        public async Task<List<Produto>> FindListServer(string serveradress)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(serveradress);

                var response = await httpClient.GetAsync(serveradress);

                using (var content = response.Content)
                {
                    var retorno = await content.ReadAsStringAsync();

                    var listaproduto = JsonConvert.DeserializeObject<List<ProdutoJson>>(retorno);

                    return listaproduto.Select(x => new Produto
                    {
                        IdProduto = Guid.NewGuid().ToString().Replace("-", ""),
                        Descricao = x.description,
                        Nome = x.name,
                        IdCategoria = x.category_id?.ToString() ?? string.Empty,
                        Foto = x.photo,
                        Favorito = false,
                        Preco = x.price

                    }).ToList();
                }
            }
        }    
    }
}