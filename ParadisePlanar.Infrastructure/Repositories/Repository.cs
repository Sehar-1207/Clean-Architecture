using Microsoft.EntityFrameworkCore;
using ParadisePlanner.Application.Common.Interfaces;
using ParadisePlanner.Domain.Entities;
using ParadisePlanner.Infrastructure.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ParadisePlanner.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;

        internal DbSet<T> dbset;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            dbset = _db.Set<T>();
        }
        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> querry = dbset;
            if (filter != null)
            {
                querry = querry.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    querry = querry.Include(includeProp);
                }
            }
            return querry.ToList();
        }

        public T GetId(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> querry = dbset;
            if (filter != null)
            {
                querry = querry.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    querry = querry.Include(includeProp);
                }
            }
            return querry.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbset.Remove(entity);
        }

        public bool Any(Expression<Func<T, bool>> filter)
        {
            return dbset.Any(filter);
        }
    }
}
