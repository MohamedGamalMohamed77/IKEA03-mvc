using LinkDev.IKEA3.DAL.Models.Departments;
using LinkDev.IKEA3.DAL.Models.Employees;
using LinkDev.IKEA3.DAL.Presistance.Repositories._Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA3.DAL.Presistance.Repositories.Employees
{
	public interface IEmployeeRepository : IGenericRepository<Employee>
	{
		int Update(Employee employee);
	}
}
