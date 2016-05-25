using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.UnitOfWork;
using System.Data.Entity;
using System.Linq.Expressions;
namespace Common.UnitOfWork.Repository
{
    public abstract class BaseRepository<T, D> : IUnitOfWorkRepository<T> where T : class where D : DbContext
    {
        protected D BaseDbContext;
        public BaseRepository(IUnitOfWork<T, D> unit)
        {
            this.BaseDbContext = unit.ManuDbContext;
        }
        public void PersistNewItem(T entity)
        {
            BaseDbContext.Set<T>().Add(entity);
        }

        public void PersistRemoveItem(T entity)
        {
            BaseDbContext.Set<T>().Remove(entity);
        }

        public void PersistUpdateItem(T entity)
        {
            BaseDbContext.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return BaseDbContext.Set<T>().Where(filter);
        }

        /// <summary>
        /// 根据指定条件返回结果集
        /// </summary>
        /// <typeparam name="OrderKey">排序字段类型</typeparam>
        /// <param name="filter">选择条件</param>
        /// <param name="key">排序字段</param>
        /// <param name="skipCount">跳过序列中指定数量的元素</param>
        /// <param name="count">选取数量</param>
        /// <param name="total">记录总数</param>
        /// <param name="isOrderDesc">是否降序</param>
        /// <returns></returns>
        public IEnumerable<T> GetAll<OrderKey>(Expression<Func<T, bool>> filter, Expression<Func<T, OrderKey>> key, int skipCount, int count, out int total, bool isOrderDesc = false)
        {
            total = BaseDbContext.Set<T>().Count(filter);
            if (isOrderDesc)
                return BaseDbContext.Set<T>().Where(filter).OrderByDescending(key).Skip(skipCount).Take(count);

            return BaseDbContext.Set<T>().Where(filter).OrderBy(key).Skip(skipCount).Take(count);
        }

        public Task<T> First(Expression<Func<T, bool>> filter)
        {
            return BaseDbContext.Set<T>().FirstAsync(filter);
        }

        public T Last(Expression<Func<T, bool>> filter)
        {
            return BaseDbContext.Set<T>().Last(filter);
        }
        public Task<int> CountAsync(Expression<Func<T, bool>> filter)
        {
            return BaseDbContext.Set<T>().CountAsync(filter);
        }

        public int Count(Expression<Func<T, bool>> filter)
        {
            return BaseDbContext.Set<T>().Count(filter);
        }
    }
}
