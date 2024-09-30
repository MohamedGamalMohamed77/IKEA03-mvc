using LinkDev.IKEA3.BLL.CustomModels.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA3.BLL.Services.Employees
{
	public interface IEmployeeService
	{
		Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(string search);
		Task<EmployeeDetailsDto?> GetEmployeeByIdAsync(int id);
		Task<int> CreatedEmployeeAsync(CreatedEmployeeDto Employee);
		Task<int> UpdatedEmployeeAsync(UpdatedEmployeeDto Employee);

		Task<bool> DeleteEmployeeAsync(int EmployeeId);
	}
}
