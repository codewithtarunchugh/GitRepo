
namespace ePizzaHub.Repositories.Interfaces
{
    //List<User>
    //IRepository<User>
    public interface IRepository<TEntity> where TEntity: class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Find(object Id);
        void Add(TEntity entity); 
        void Update(TEntity entity);
        void Delete(object Id);
        int SaveChanges();
    }
}
