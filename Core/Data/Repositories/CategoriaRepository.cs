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
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository() : base(true)
        {
        }
        public async Task<List<Categoria>> FindListServer(string serveradress)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(serveradress);

                var response = await httpClient.GetAsync(serveradress);

                using (var content = response.Content)
                {
                    var retorno = await content.ReadAsStringAsync();

                    var listacategoria = JsonConvert.DeserializeObject<List<CategoriaJson>>(retorno);

                    return listacategoria.Select(x => new Categoria
                    {
                        Id = x.id.ToString(),
                        Descricao = x.name

                    }).ToList();
                }
            }
        }
        
        public override List<Categoria> FindList()
        {
            var lista = base.FindList();

            lista.Add(new Categoria
            {
                Id = "0",
                Descricao = "Todas as categorias",
                Selecionado = true
            });

            return lista;
        }
    }
}