using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeusPedidos.Catalogo.Core.Domain.Interfaces.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : IEntidadeBase
    {
        Task<bool> InsertAsync(TEntity entity);

        Task<bool> InsertRangeAsync(IEnumerable<TEntity> entidades);

        Task<bool> UpdateAsync(TEntity entity);

        Task<bool> DeleteAsync(TEntity entity);

        bool Insert(TEntity entity);

        bool InsertRange(IEnumerable<TEntity> entidades);

        bool Update(TEntity entity);

        bool Delete(TEntity entity);

        bool DeleteAll();

        Task<TEntity> FindAsync();

        Task<List<TEntity>> FindListAsync();

        TEntity Find();

        List<TEntity> FindList();
    }
}