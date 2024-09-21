using LinkDev.IKEA3.DAL.Models.Department;
using LinkDev.IKEA3.DAL.Presistance.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA3.DAL.Presistance.Repositories.Departments
{
    public class DepartmentRepositories : IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DepartmentRepositories(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Department> GetAll(bool WithNoTracking = true)
        {
            if (WithNoTracking)
                return _dbContext.Departments.AsNoTracking().ToList();
            return _dbContext.Departments.ToList();
        }
        public IQueryable<Department> GetAllAsIQueryable()
        {
            return _dbContext.Departments;
        }
        public Department? GetById(int id)
        {
            return _dbContext.Departments.Find(id);

        } 

        public int Add(Department department)
        {
            _dbContext.Departments.Add(department);
            return _dbContext.SaveChanges();
        }

        public bool Delete(Department department)
        {
            _dbContext.Departments.Remove(department);
            return _dbContext.SaveChanges()>0;
        }


        public int Update(Department department)
        {
            _dbContext.Departments.Update(department);
            return _dbContext.SaveChanges();
        }

    }
}
