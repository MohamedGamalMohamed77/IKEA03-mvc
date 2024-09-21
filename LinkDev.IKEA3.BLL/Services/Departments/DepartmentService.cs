using LinkDev.IKEA3.BLL.CustomModels.Departments;
using LinkDev.IKEA3.DAL.Models.Department;
using LinkDev.IKEA3.DAL.Presistance.Repositories.Departments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA3.BLL.Services.Departments
{
    public class DepartmentService : IDepartmentService
    {
        private IDepartmentRepository _departmeentRepository;
        public DepartmentService(IDepartmentRepository departmeentRepository)
        {
            _departmeentRepository = departmeentRepository;
        }
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _departmeentRepository.GetAllAsIQueryable().Select(department => new DepartmentDto
            {
                Id = department.Id,
                Code = department.Code,
                Name = department.Name,
                CreationDate = department.CreationDate
            }).AsNoTracking().ToList();

            return departments;
        }
        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            var department = _departmeentRepository.GetById(id);
            if (department != null)
                return new DepartmentDetailsDto()
                {
                    Id = department.Id,
                    Code = department.Code,
                    Name = department.Name,
                    Description = department.Description,
                    CreationDate = department.CreationDate,
                    CreatedBy = department.CreatedBy,
                    CreatedOn = department.CreatedOn,
                    LastModifiedBy = department.LastModifiedBy,
                    LastModifiedOn = department.LastModifiedOn,
                };
            return null;
        }
        public int CreatedDepartment(CreatedDepartmentDto department)
        {
            var createdDepartment = new Department()
            {
                Code = department.Code,
                Name = department.Name,
                Description = department.Description!,
                CreationDate = department.CreationDate,
                CreatedBy = 1,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.UtcNow
            };
            return _departmeentRepository.Add(createdDepartment);
        }
        public int UpdatedDepartment(UpdatedDepartmentDto department)
        {
            var createdDepartment = new Department()
            {
                Id = department.Id,
                Code = department.Code,
                Name = department.Name,
                Description = department.Description!,
                CreationDate = department.CreationDate,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.UtcNow
            };
            return _departmeentRepository.Update(createdDepartment);
        }
        public  bool DeleteDepartment(int departmentId)
        {

            var department = _departmeentRepository.GetById(departmentId);
            if (department is { })
                return _departmeentRepository.Delete(department);
            return false;
        }

    }
}
