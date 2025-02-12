namespace BackEnd_KorpsDesafio.ORM.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Add(T entity);
        T Update(T entity);        

    }
}
