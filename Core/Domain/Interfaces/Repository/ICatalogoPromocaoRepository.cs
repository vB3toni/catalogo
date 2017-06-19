using System.Collections.Generic;
using System.Threading.Tasks;
using MeusPedidos.Catalogo.Core.Domain.Entidades;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Base;

namespace MeusPedidos.Catalogo.Core.Domain.Interfaces.Repository
{
    public interface ICatalogoPromocaoRepository : IRepositoryBase<CatalogoPromocao>
    {
        List<CatalogoPromocao> BuscarTodosCatalogoPromocao(string idcategoria);


    }
}