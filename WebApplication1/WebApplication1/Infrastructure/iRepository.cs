namespace WebApplication1.Infrastructure
{
    public interface IRepository<TEntity, TKey>
    {
        //Designed to perform CRUD Operations = Create, Update, Retrive, Delete
        //TEntity - represents a Model Type
        //TKey = represents the Datatype of the key field (Primary Key) in the Model Object

        TEntity FindById(TKey id);

        IEnumerable<TEntity> FindAll();
        
        void AddNew(TEntity entity);
        
        void DeleteById(TKey id);

        void Update(TEntity entity);
    }
}
