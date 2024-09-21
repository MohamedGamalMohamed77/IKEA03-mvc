using LinkDev.IKEA3.DAL.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA3.DAL.Presistance.Repositories.Departments
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll(bool WithNoTracking = true);
        IQueryable<Department> GetAllAsIQueryable();
        Department? GetById(int id);
        int Add(Department department);
        int Update(Department department);
        bool Delete(Department department);

    }
}
