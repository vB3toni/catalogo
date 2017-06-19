namespace MeusPedidos.Catalogo.Core.Data.Configuration.Json
{
    public class ProdutoJson
    {
        public string name { get; set; }
        public string description { get; set; }
        public string photo { get; set; }
        public double price { get; set; }
        public int? category_id { get; set; }
    }
}