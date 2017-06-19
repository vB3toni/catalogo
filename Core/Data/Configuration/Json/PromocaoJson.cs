using System.Collections.Generic;

namespace MeusPedidos.Catalogo.Core.Data.Configuration.Json
{
    public class PromocaoJson
    {
        public string name { get; set; }
        public int category_id { get; set; }
        public List<PoliticaJson> policies { get; set; }
    }
}