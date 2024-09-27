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
		IEnumerable<T> GetAll(bool WithNoTracking = true);
		IQueryable<T> GetAllAsIQueryable();
        IEnumerable<T> GetAllAsIEnumerable();
        T? GetById(int id);
		void Add(T T);
		void Update(T T);
		void Delete(T T);
	}
}
