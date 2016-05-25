using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Common.UnitOfWork
{
    public interface IUnitOfWorkRepository<T> where T : class
    {
        void PersistNewItem(T entity);
        void PersistUpdateItem(T entity);

        void PersistRemoveItem(T entity);
    }

    public interface IUnitOfWork<T, D> where D : DbContext where T : class
    {
        void RegisterAdd(T entity, IUnitOfWorkRepository<T> repository);

        void RegisterUpdate(T entity, IUnitOfWorkRepository<T> repository);

        void RegisterRemove(T entity, IUnitOfWorkRepository<T> repository);

        Task<int> Commit();
        void Commit(bool synchronized);
        D ManuDbContext { get; }
    }
}
