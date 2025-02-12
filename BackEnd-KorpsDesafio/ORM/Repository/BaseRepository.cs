
using BackEnd_KorpsDesafio.ORM.Context;

namespace BackEnd_KorpsDesafio.ORM.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public KorpsDbContext _context;
        public BaseRepository(KorpsDbContext context)
        {
            _context = context;

        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }
    }
}
