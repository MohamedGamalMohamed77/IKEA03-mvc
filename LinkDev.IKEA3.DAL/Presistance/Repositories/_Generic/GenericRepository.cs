using LinkDev.IKEA3.DAL.Models;
using LinkDev.IKEA3.DAL.Presistance.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA3.DAL.Presistance.Repositories._Generic
{
    public class GenericRepository<T> where T : ModelBase
    {
        private protected readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<T>> GetAllAsync(bool WithNoTracking = true)
        {
            if (WithNoTracking)
                return await _dbContext.Set<T>().Where(X => !X.IsDeleted).AsNoTracking().ToListAsync();

            return await _dbContext.Set<T>().Where(X => !X.IsDeleted).ToListAsync();
        }
        public IQueryable<T> GetAllAsIQueryable()
        {
            return _dbContext.Set<T>();
        }
        public IQueryable<T> GetAllAsIEnumerable()
        {
            return _dbContext.Set<T>();
        }
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);

        }

        public void Add(T T)
        {
            _dbContext.Set<T>().Add(T);
        }

        public void Delete(T T)
        {
            T.IsDeleted = true;
            _dbContext.Set<T>().Update(T);
        }


        public void Update(T T)
        {
            _dbContext.Set<T>().Update(T);
        }

    }
}
