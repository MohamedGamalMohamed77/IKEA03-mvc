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
		IEnumerable<EmployeeDto> GetAllEmployees();
		EmployeeDetailsDto? GetEmployeeById(int id);
		int CreatedEmployee(CreatedEmployeeDto Employee);
		int UpdatedEmployee(UpdatedEmployeeDto Employee);

		bool DeleteEmployee(int EmployeeId);
	}
}
