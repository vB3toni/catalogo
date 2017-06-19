using System.Collections.Generic;
using System.Threading.Tasks;
using MeusPedidos.Catalogo.Core.Domain.Validacoes;

namespace MeusPedidos.Catalogo.Core.Domain.Interfaces.Base
{
    public interface IApplicationBase<TEntity> where TEntity : IEntidadeBase
    {
        ValidacaoResult Inserir(TEntity entity);

        ValidacaoResult InserirRange(IEnumerable<TEntity> entidades);

        ValidacaoResult Atualizar(TEntity entity);

        ValidacaoResult Apagar(TEntity entity);

        ValidacaoResult ValidarEntidade(TEntity entity);

        ValidacaoResult Insert(TEntity entity);

        ValidacaoResult InsertRange(IEnumerable<TEntity> entidades);

        ValidacaoResult Update(TEntity entity);

        ValidacaoResult Delete(TEntity entity);

        Task<TEntity> FindAsync();

        Task<List<TEntity>> FindListAsync();

        TEntity Find();

        List<TEntity> FindList();
    }
}