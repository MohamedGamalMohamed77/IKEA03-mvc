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
        IEnumerable<DepartmentDto> GetAllDepartments();
        DepartmentDetailsDto? GetDepartmentById(int id);
        int CreatedDepartment(CreatedDepartmentDto department);
        int UpdatedDepartment(UpdatedDepartmentDto department);

        bool DeleteDepartment(int departmentId);

    }
}
