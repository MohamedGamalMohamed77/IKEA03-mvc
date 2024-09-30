using LinkDev.IKEA3.DAL.Presistance.Data;
using LinkDev.IKEA3.DAL.Presistance.Repositories.Departments;
using LinkDev.IKEA3.DAL.Presistance.Repositories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA3.DAL.Presistance.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public IEmployeeRepository employeeRepository => new EmployeeRepository(_dbContext);

        public IDepartmentRepository departmentRepository => new DepartmentRepository(_dbContext);

        public UnitOfWork(ApplicationDbContext dbContext) 
        {
        _dbContext=dbContext;
        }

        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
        public async ValueTask DisposeAsync() 
        {
        await _dbContext.DisposeAsync();
        }

    }
}
