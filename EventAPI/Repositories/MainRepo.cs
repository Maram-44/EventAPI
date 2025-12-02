using EventAPI.Data;
using EventAPI.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EventAPI.Repositories
{
    public class MainRepo<T> :IMainRepo<T> where T : class
    {
        private readonly EventContext context;

        public MainRepo(EventContext context)
        {
            this.context = context;
        }
        public T FindById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public T SelectOne(Expression<Func<T, bool>> match)
        {
            return context.Set<T>().SingleOrDefault(match);
        }

        public IEnumerable<T> FindAll()
        {
            return context.Set<T>().ToList();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public IEnumerable<T> FindAll(params string[] agers)
        {
            IQueryable<T> query = context.Set<T>();

            if (agers.Length > 0)
            {
                foreach (var ager in agers)
                {
                    query = query.Include(ager);
                }
            }

            return query.ToList();
        }

        public async Task<IEnumerable<T>> FindAllAsync(params string[] agers)
        {
            IQueryable<T> query = context.Set<T>();

            if (agers.Length > 0)
            {
                foreach (var ager in agers)
                {
                    query = query.Include(ager);
                }
            }

            return await query.ToListAsync();
        }

        //=========================================================================//

        public void AddOne(T myItem)
        {
            context.Set<T>().Add(myItem);
            context.SaveChanges();
        }

        public void UpdateOne(T myItem)
        {
            context.Set<T>().Update(myItem);
            context.SaveChanges();
        }

        public void DeleteOne(T myItem)
        {
            context.Set<T>().Remove(myItem);
            context.SaveChanges();
        }

        public void AddList(IEnumerable<T> myList)
        {
            context.Set<T>().AddRange(myList);
            context.SaveChanges();
        }

        public void UpdateList(IEnumerable<T> myList)
        {
            context.Set<T>().UpdateRange(myList);
            context.SaveChanges();
        }

        public void DeleteList(IEnumerable<T> myList)
        {
            context.Set<T>().RemoveRange(myList);
            context.SaveChanges();
        }

        public async Task AddOneAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateOneAsync(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteOneAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            IQueryable<T> query = context.Set<T>();

            foreach (var inc in includes)
                query = query.Include(inc);

            return await query.Where(predicate).ToListAsync();
        }

    }
}
