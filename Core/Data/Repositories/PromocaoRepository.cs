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
    public class PromocaoRepository : RepositoryBase<Promocao>, IPromocaoRepository
    {
        public PromocaoRepository() : base(true)
        {
        }

        public async Task<List<Promocao>> FindListServer(string serveradress)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(serveradress);

                var response = await httpClient.GetAsync(serveradress);

                using (var content = response.Content)
                {
                    var retorno = await content.ReadAsStringAsync();

                    var listapromocao = JsonConvert.DeserializeObject<List<PromocaoJson>>(retorno);

                    var listapromo = new List<Promocao>();
                    
                    foreach (var promocaoJson in listapromocao)
                    {
                        var promocao = new Promocao
                        {
                            IdPromocao = Guid.NewGuid().ToString().Replace("-", ""),
                            Descricao = promocaoJson.name,
                            IdCategoria = promocaoJson.category_id.ToString()
                        };

                        var listapoliticapromocao = promocaoJson.policies.Select(policy => new Politica
                        {
                            IdPromocao = promocao.IdPromocao,
                            QtdeMinima = policy.min,
                            Desconto = policy.discount
                        })
                        .ToList();

                        promocao.Politica = listapoliticapromocao;

                        listapromo.Add(promocao);
                    }

                    return listapromo;
                }
            }
        }

        public override bool Insert(Promocao entity)
        {
            try
            {
                entity.Politica = null;

                return base.Insert(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}