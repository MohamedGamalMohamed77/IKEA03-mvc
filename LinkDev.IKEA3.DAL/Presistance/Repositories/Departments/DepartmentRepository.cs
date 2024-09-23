using LinkDev.IKEA3.DAL.Models.Department;
using LinkDev.IKEA3.DAL.Presistance.Data;
using LinkDev.IKEA3.DAL.Presistance.Repositories._Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA3.DAL.Presistance.Repositories.Departments
{
	public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
	{
		public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}


	}
}
