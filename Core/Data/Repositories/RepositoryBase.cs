using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Base;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.Generic;

namespace MeusPedidos.Catalogo.Core.Data.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, IEntidadeBase
    {
        protected readonly SQLiteAsyncConnection SqLiteAsyncConnection;
        protected readonly SQLiteConnection SqliteConnection;

        protected RepositoryBase(bool criartabela)
        {
            SqLiteAsyncConnection = new SQLiteAsyncConnection(() => new SQLiteConnectionWithLock(new SQLitePlatformGeneric(), new SQLiteConnectionString(Configuration.Configuration.DatabaseFilePath, false)));

            SqliteConnection = new SQLiteConnection(new SQLitePlatformGeneric(), Configuration.Configuration.DatabaseFilePath, false);

            if (criartabela)
            {
                SqliteConnection.CreateTable<TEntity>();
            }
        }

        public virtual async Task<bool> InsertAsync(TEntity entity)
        {
            var result = await SqLiteAsyncConnection.InsertAsync(entity);

            return result > 0;
        }

        public async Task<bool> InsertRangeAsync(IEnumerable<TEntity> entidades)
        {
            var result = await SqLiteAsyncConnection.InsertAllAsync(entidades);

            return result > 0;
        }

        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            var result = await SqLiteAsyncConnection.UpdateAsync(entity);

            return result > 0;
        }

        public virtual async Task<bool> DeleteAsync(TEntity entity)
        {
            var result = await SqLiteAsyncConnection.DeleteAsync(entity);

            return result > 0;
        }

        public virtual bool Insert(TEntity entity)
        {
            var result = SqliteConnection.Insert(entity);

            return result > 0;
        }

        public virtual bool InsertRange(IEnumerable<TEntity> entidades)
        {
            var result = SqliteConnection.InsertAll(entidades);

            return result > 0;
        }

        public virtual bool Update(TEntity entity)
        {
            var result = SqliteConnection.Update(entity);

            return result > 0;
        }

        public virtual bool Delete(TEntity entity)
        {
            var result = SqliteConnection.Delete(entity);

            return result > 0;
        }

        public bool DeleteAll()
        {
            var result = SqliteConnection.DeleteAll<TEntity>();

            return result > 0;
        }

        public virtual async Task<TEntity> FindAsync()
        {
            var result = await SqLiteAsyncConnection.FindAsync<TEntity>(x => x.EntidadeValida);

            return result;
        }

        public virtual async Task<List<TEntity>> FindListAsync()
        {
            var result = await SqLiteAsyncConnection.Table<TEntity>().ToListAsync();

            return result;
        }

        public virtual TEntity Find()
        {
            return SqliteConnection.Find<TEntity>(x => x.EntidadeValida);
        }

        public virtual List<TEntity> FindList()
        {
            return SqliteConnection.Table<TEntity>().ToList();
        }
    }
}