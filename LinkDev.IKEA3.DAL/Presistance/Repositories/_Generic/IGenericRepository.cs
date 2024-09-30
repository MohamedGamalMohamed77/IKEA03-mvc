using LinkDev.IKEA3.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA3.DAL.Presistance.Repositories._Generic
{
	public interface IGenericRepository<T> where T : ModelBase
	{
		Task<IEnumerable<T>> GetAllAsync(bool WithNoTracking = true);
		Task<T?> GetByIdAsync(int id);
		IQueryable<T> GetAllAsIQueryable();
        IEnumerable<T> GetAllAsIEnumerable();
		void Add(T T);
		void Update(T T);
		void Delete(T T);

	}
}
