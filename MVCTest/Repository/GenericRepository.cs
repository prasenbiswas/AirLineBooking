using Microsoft.EntityFrameworkCore;
using MVCTest.DbContext;

namespace MVCTest.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private AppDbContext _context = null;
        private DbSet<T> table = null;

        //public GenericRepository()
        //{
        //    this._context = new AppDbContext();
        //    //Whatever class name we specify while creating the instance of GenericRepository
        //    //That class name will be stored in the table variable
        //    table = _context.Set<T>();
        //}
        public GenericRepository(AppDbContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
