using LinkDev.IKEA3.BLL.CustomModels.Departments;
using LinkDev.IKEA3.DAL.Models.Departments;
using LinkDev.IKEA3.DAL.Presistance.Repositories.Departments;
using LinkDev.IKEA3.DAL.Presistance.UnitOfWork;
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
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync()
        {
            var departments = await _unitOfWork.departmentRepository.GetAllAsIQueryable().Where(D=>!D.IsDeleted).Select(department => new DepartmentDto
            {
                Id = department.Id,
                Code = department.Code,
                Name = department.Name,
                CreationDate = department.CreationDate,
            }).AsNoTracking().ToListAsync();

            return departments;
        }
        public async  Task<DepartmentDetailsDto?> GetDepartmentByIdAsync(int id)
        {
            var department = await _unitOfWork.departmentRepository.GetByIdAsync(id);
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
        public async Task<int> CreatedDepartmentAsync(CreatedDepartmentDto department)
        {
            var createdDepartment = new Department()
            {
                Code = department.Code,
                Name = department.Name,
                Description = department.Description!,
                CreationDate = department.CreationDate,
                CreatedBy = 1,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.UtcNow,
                IsDeleted=false
              
            };
           _unitOfWork.departmentRepository.Add(createdDepartment);
            return await _unitOfWork.CompleteAsync();
        }
        public async Task<int> UpdatedDepartmentAsync(UpdatedDepartmentDto department)
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
             _unitOfWork.departmentRepository.Update(createdDepartment);
            return await _unitOfWork.CompleteAsync();
        }
        public  async Task<bool> DeleteDepartmentAsync(int departmentId)
        {
            var departmentRepo = _unitOfWork.departmentRepository;
            var department = await departmentRepo.GetByIdAsync(departmentId);
            if (department is { })
                departmentRepo.Delete(department);
            return await _unitOfWork.CompleteAsync()>0;
        }

    }
}
