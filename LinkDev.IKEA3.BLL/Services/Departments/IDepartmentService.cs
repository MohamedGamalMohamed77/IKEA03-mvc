using LinkDev.IKEA3.BLL.CustomModels.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA3.BLL.Services.Departments
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync();
        Task<DepartmentDetailsDto?> GetDepartmentByIdAsync(int id);
        Task<int> CreatedDepartmentAsync(CreatedDepartmentDto department);
        Task<int> UpdatedDepartmentAsync(UpdatedDepartmentDto department);
        Task<bool> DeleteDepartmentAsync(int departmentId);

    }
}
