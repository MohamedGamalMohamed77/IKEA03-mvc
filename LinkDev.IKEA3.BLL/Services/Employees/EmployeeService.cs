using LinkDev.IKEA3.BLL.CustomModels.Employees;
using LinkDev.IKEA3.DAL.Models.Employees;
using LinkDev.IKEA3.DAL.Presistance.Repositories.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA3.BLL.Services.Employees
{
	public class EmployeeService : IEmployeeService
	{
		private readonly IEmployeeRepository _employeeRepository;
		public EmployeeService(IEmployeeRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}

		public int CreatedEmployee(CreatedEmployeeDto createdEmployee)
		{
			var employee = new Employee()
			{
				Name = createdEmployee.Name,
				Age = createdEmployee.Age,
				Address = createdEmployee.Address,
				HiringDate = createdEmployee.HiringDate,
				Salary = createdEmployee.Salary,
				Email = createdEmployee.Email,
				Gender = createdEmployee.Gender,
				EmployeeType = createdEmployee.EmployeeType,
				PhoneNumber = createdEmployee.PhoneNumber,
				IsActive=createdEmployee.IsActive,
				LastModifiedBy = 1,
				CreatedBy = 1,
				LastModifiedOn = DateTime.UtcNow,
				DepartmentId=createdEmployee.DepartmentId,
			};
			return _employeeRepository.Add(employee);
		}
		public int UpdatedEmployee(UpdatedEmployeeDto updatedEmployee)
		{
			var employee = new Employee()
			{
				Id=updatedEmployee.Id,
				Name = updatedEmployee.Name,
				Age = updatedEmployee.Age,
				Address = updatedEmployee.Address,
				HiringDate = updatedEmployee.HiringDate,
				Salary = updatedEmployee.Salary,
				Email = updatedEmployee.Email,
				Gender = updatedEmployee.Gender,
				EmployeeType = updatedEmployee.EmployeeType,
				PhoneNumber = updatedEmployee.PhoneNumber,
				LastModifiedBy = 1,
				CreatedBy = 1,
				LastModifiedOn = DateTime.UtcNow,
				DepartmentId=updatedEmployee.DepartmentId,
				
			};
			return _employeeRepository.Update(employee);
		}
		public bool DeleteEmployee(int EmployeeId)
		{
			var employee = _employeeRepository.GetById(EmployeeId);
			if (employee is { })
				return _employeeRepository.Delete(employee);
			return false;
		}

		public IEnumerable<EmployeeDto> GetEmployees(string search)
		{
		 var employees= _employeeRepository
				.GetAllAsIQueryable()
				.Where(E=>!E.IsDeleted && (string.IsNullOrEmpty(search)||E.Name.ToLower().Contains(search.ToLower())))
				.Include(E=>E.Department)
				.Select(employee=> new EmployeeDto() 
		 {
			 Id = employee.Id,
			 Name = employee.Name,
			 Age = employee.Age,
			 Salary = employee.Salary,
			 Email = employee.Email,
			 Gender = employee.Gender.ToString(),
			 EmployeeType = employee.EmployeeType.ToString(),
			 Department=employee.Department.Name
         }).AsNoTracking().ToList();

			return employees;
		}

		public EmployeeDetailsDto? GetEmployeeById(int id)
		{
			var employee = _employeeRepository.GetById(id);
			if (employee is { })
				return new EmployeeDetailsDto()
				{
					Id = employee.Id,
					Name = employee.Name,
					Age = employee.Age,
					Address = employee.Address,
					HiringDate = employee.HiringDate,
					Salary = employee.Salary,
					Email = employee.Email,
					Gender = employee.Gender,
					EmployeeType = employee.EmployeeType,
					PhoneNumber = employee.PhoneNumber,
			};

			return null;
		}


	}
}
