using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Base;
using MeusPedidos.Catalogo.Core.Domain.Validacoes;

namespace MeusPedidos.Catalogo.Core.Application.Services
{
    public abstract class ServiceBase<TEntity> : IApplicationBase<TEntity> where TEntity : IEntidadeBase
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;

        protected ServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public ValidacaoResult Inserir(TEntity entity)
        {
            var validacaoresult = ValidarEntidade(entity);

            if (validacaoresult.IsValid)
            {
                var taskinsert = _repositoryBase.InsertAsync(entity).ContinueWith(task =>
                {
                    if (task.IsCompleted && task.Result)
                    {
                        return new ValidacaoResult("Inserido com sucesso");
                    }

                    return new ValidacaoResult(false, "Problema ao inserir registro");
                });

                taskinsert.ConfigureAwait(false);
            }

            return validacaoresult;
        }

        public ValidacaoResult InserirRange(IEnumerable<TEntity> entidades)
        {
            entidades = entidades as IList<TEntity> ?? entidades.ToList();
            foreach (var entity in entidades)
            {
                var validacao = ValidarEntidade(entity);
                if (!validacao.IsValid)
                {
                    return validacao;
                }
            }

            var taskinsert = _repositoryBase.InsertRangeAsync(entidades).ContinueWith(task =>
            {
                if (task.IsCompleted && task.Result)
                {
                    return new ValidacaoResult("Registros inseridos com sucesso");
                }
                return new ValidacaoResult(false, "Problema ao inserir lista registros");
            });

            taskinsert.ConfigureAwait(false);

            return new ValidacaoResult(false, "Erro ao salvar registros");
        }

        public ValidacaoResult Atualizar(TEntity entity)
        {
            var validacaoresult = ValidarEntidade(entity);

            if (validacaoresult.IsValid)
            {
                var taskinsert = _repositoryBase.UpdateAsync(entity).ContinueWith(task =>
                {
                    if (task.IsCompleted && task.Result)
                    {
                        return new ValidacaoResult("Atualizado com sucesso");
                    }
                    return new ValidacaoResult(false, "Problema ao atualizar registro");
                });

                taskinsert.ConfigureAwait(false);

                
            }

            return validacaoresult;
        }

        public ValidacaoResult Apagar(TEntity entity)
        {
            var validacaoresult = ValidarEntidade(entity);

            if (validacaoresult.IsValid)
            {
                var taskinsert = _repositoryBase.DeleteAsync(entity);

                Task.WaitAny(taskinsert);

                if (taskinsert.IsCompleted && taskinsert.Result)
                {
                    return new ValidacaoResult("Apagado com sucesso");
                }
            }

            return validacaoresult;
        }

        public abstract ValidacaoResult ValidarEntidade(TEntity entity);
        public ValidacaoResult Insert(TEntity entity)
        {
            var validacaoresult = ValidarEntidade(entity);

            if (validacaoresult.IsValid)
            {
                var result = _repositoryBase.Insert(entity);

                return result ? new ValidacaoResult("registro inserido com sucesso") : new ValidacaoResult(false, "Problema ao inserir registro");
            }

            return validacaoresult;
        }

        public ValidacaoResult InsertRange(IEnumerable<TEntity> entidades)
        {
            entidades = entidades as IList<TEntity> ?? entidades.ToList();
            foreach (var entity in entidades)
            {
                var validacao = ValidarEntidade(entity);
                if (!validacao.IsValid)
                {
                    return validacao;
                }
            }

            var result = _repositoryBase.InsertRange(entidades);

            return result ? new ValidacaoResult("registro inserido com sucesso") : new ValidacaoResult(false, "Problema ao inserir registro");
        }

        public ValidacaoResult Update(TEntity entity)
        {
            var validacaoresult = ValidarEntidade(entity);

            if (validacaoresult.IsValid)
            {
                var result = _repositoryBase.Update(entity);

                return result ? new ValidacaoResult("registro atualizado com sucesso") : new ValidacaoResult(false, "Problema ao atualizar registro");
            }

            return validacaoresult;
        }

        public ValidacaoResult Delete(TEntity entity)
        {
            var validacaoresult = ValidarEntidade(entity);

            if (validacaoresult.IsValid)
            {
                var result = _repositoryBase.Delete(entity);

                return result ? new ValidacaoResult("registro apagado com sucesso") : new ValidacaoResult(false, "Problema ao apagar registro");
            }

            return validacaoresult;
        }

        TEntity IApplicationBase<TEntity>.Find()
        {
            return _repositoryBase.Find();
        }

        List<TEntity> IApplicationBase<TEntity>.FindList()
        {
            return _repositoryBase.FindList();
        }

        public Task<TEntity> FindAsync()
        {
            return _repositoryBase.FindAsync();
        }

        public Task<List<TEntity>> FindListAsync()
        {
            return _repositoryBase.FindListAsync();
        }
    }
}