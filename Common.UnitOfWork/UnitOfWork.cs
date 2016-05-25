using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.UnitOfWork
{
    public class UnitOfWork<T, D> : IUnitOfWork<T, D> where T : class where D : DbContext
    {
        private D manufactory;

        public D ManuDbContext
        {
            get
            {
                return this.manufactory as D;
            }
        }

        public UnitOfWork(D dbContext)
        {
            this.manufactory = dbContext;
        }

        public void RegisterAdd(T entity, IUnitOfWorkRepository<T> repository)
        {
            repository.PersistNewItem(entity);
        }

        public void RegisterRemove(T entity, IUnitOfWorkRepository<T> repository)
        {
            repository.PersistRemoveItem(entity);
        }

        public void RegisterUpdate(T entity, IUnitOfWorkRepository<T> repository)
        {
            repository.PersistUpdateItem(entity);
        }

        public async Task<int> Commit()
        {
            return await manufactory.SaveChangesAsync();
        }

        public void Commit(bool synchronized)
        {
            manufactory.SaveChanges();
        }
    }
}
