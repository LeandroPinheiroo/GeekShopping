using GeekShopping.ProductAPI.Model.Base;
using GeekShopping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GeekShopping.ProductAPI.Repository
{
    public class GenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly MySQLContext _context;
        public GenericRepository(MySQLContext context)
        {
            _context = context;
        }
        public TEntity Save(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return entity;
        }

        public bool Delete(long id)
        {
            TEntity? entity = FindById(id);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                return true;
            }
            return false;
        }

        public IEnumerable<TEntity> FindAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity? FindById(long id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public TEntity Update(TEntity entity)
        {
            if (FindById(entity.Id) != null)
            {
                _context.Set<TEntity>().Add(entity);
            }
            return entity;
        }
    }
}
