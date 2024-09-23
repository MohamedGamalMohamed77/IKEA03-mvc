using LinkDev.IKEA3.DAL.Models.Employee;
using LinkDev.IKEA3.DAL.Presistance.Data;
using LinkDev.IKEA3.DAL.Presistance.Repositories._Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA3.DAL.Presistance.Repositories.Employees
{
	public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
	{
		public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}
