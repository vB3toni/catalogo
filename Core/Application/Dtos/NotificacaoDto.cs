namespace MeusPedidos.Catalogo.Core.Application.Dtos
{
    public class NotificacaoDto
    {
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public bool NotificarComSom { get; set; }

        public bool NotificarComVibracao { get; set; }

        public bool NotificarComLuz { get; set; }
    }
}