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
	public class GenericRepository<T> where T:ModelBase
	{
		private protected readonly ApplicationDbContext _dbContext;

		public GenericRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public IEnumerable<T> GetAll(bool WithNoTracking = true)
		{
			if (WithNoTracking)
				return _dbContext.Set<T>().Where(X =>!X.IsDeleted).AsNoTracking().ToList();

			return _dbContext.Set<T>().Where(X=>!X.IsDeleted).ToList();
		}
		public IQueryable<T> GetAllAsIQueryable()
		{
			return _dbContext.Set<T>();
		}
		public T? GetById(int id)
		{
			return _dbContext.Set<T>().Find(id);

		}

		public int Add(T T)
		{
			_dbContext.Set<T>().Add(T);
			return _dbContext.SaveChanges();
		}

		public bool Delete(T T)
		{
			T.IsDeleted = true;
			_dbContext.Set<T>().Update(T);
			return _dbContext.SaveChanges() > 0;
		}


		public int Update(T T)
		{
			_dbContext.Set<T>().Update(T);
			return _dbContext.SaveChanges();
		}

	}
}
