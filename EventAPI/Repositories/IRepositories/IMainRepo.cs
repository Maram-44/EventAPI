using System.Linq.Expressions;

namespace EventAPI.Repositories.IRepositories
{
    public interface IMainRepo<T> where T : class
    {
        T FindById(int id);

        T SelectOne(Expression<Func<T, bool>> match);

        IEnumerable<T> FindAll();

        IEnumerable<T> FindAll(params string[] agers);

        Task<T> FindByIdAsync(int id);

        Task<IEnumerable<T>> FindAllAsync();

        Task<IEnumerable<T>> FindAllAsync(params string[] agers);

        void AddOne(T myItem);

        void UpdateOne(T myItem);

        void DeleteOne(T myItem);

        void AddList(IEnumerable<T> myList);

        void UpdateList(IEnumerable<T> myList);

        void DeleteList(IEnumerable<T> myList);

        Task AddOneAsync(T entity);
        Task UpdateOneAsync(T entity);
        Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

        Task DeleteOneAsync(T entity);

        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, params string[] includes);
    }
}
