using LinkDev.IKEA3.BLL.CustomModels.Departments;
using LinkDev.IKEA3.BLL.CustomModels.Employees;
using LinkDev.IKEA3.BLL.Services.Employees;
using LinkDev.IKEA3.DAL.Models.Department;
using LinkDev.IKEA3.DAL.Models.Employee;
using LinkDev.IKEA3.PL.ViewModels.Departments;
using LinkDev.IKEA3.PL.ViewModels.Employees;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.IKEA3.PL.Controllers.Employees
{
	public class EmployeeController : Controller
	{
		#region Services

		private readonly IEmployeeService _employeeService;
		private readonly ILogger<EmployeeController> _logger;
		private readonly IWebHostEnvironment _environment;

		public EmployeeController(IEmployeeService employeeService,
			ILogger<EmployeeController> logger,
			IWebHostEnvironment environment)
		{
			_logger = logger;
			_environment = environment;
			_employeeService = employeeService;
		}
		#endregion

		#region Index
		[HttpGet]
		public IActionResult Index()
		{
			var employee = _employeeService.GetAllEmployees();
			return View(employee);
		}

		#endregion

		#region Create
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(CreatedEmployeeDto employee)
		{
			if (ModelState.IsValid)
				return View(employee);
           

            var message = string.Empty;

			try
			{
				var result = _employeeService.CreatedEmployee(employee);
				if (result > 0)
					return RedirectToAction(nameof(Index));
				else
				{
					message = "employee isn't Created";
					ModelState.AddModelError(string.Empty, message);
					return View(employee);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);

				message = _environment.IsDevelopment() ? ex.Message : "an error has occured during updating the employee  :( ";

			}

			ModelState.AddModelError(string.Empty, message);
			return View(employee);
		}

		#endregion


		#region Details
		[HttpGet]
		public IActionResult Details(int? id)
		{
			if (id is null)
				return BadRequest();

			var employee = _employeeService.GetEmployeeById(id.Value);

			if (employee is null)
				return NotFound();

			return View(employee);
		}
		#endregion

		#region Edit

		[HttpGet]
		public IActionResult Edit(int? id)
		{
			if (id is null)
				return BadRequest();

			var employee = _employeeService.GetEmployeeById(id.Value);

			if (employee is null)
				return NotFound();

			return View(new EmployeeEditViewModel()
			{
				Name=employee.Name,
				Age=employee.Age,
				Salary=employee.Salary,
				Email=employee.Email,
				IsActive=employee.IsActive,
			});
		}

		[HttpPost]
		public IActionResult Edit([FromRoute] int id, EmployeeEditViewModel employee)
		{
			if (!ModelState.IsValid)
				return View(employee);
			var message = string.Empty;
			try
			{
				var employeeToUpdate = new UpdatedEmployeeDto()
				{
					Name = employee.Name,
					Age = employee.Age,
					Salary = employee.Salary,
					Email = employee.Email,
					IsActive = employee.IsActive,
				};
				var result = _employeeService.UpdatedEmployee(employeeToUpdate) > 0;

				if (result)
					return RedirectToAction("Index");
				message = "an error has occured during updating the employee  :( ";

			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);

				message = _environment.IsDevelopment() ? ex.Message : "an error has occured during updating the employee  :( ";

			}

			ModelState.AddModelError(string.Empty, message);
			return View(employee);
		}
		#endregion

		#region Delete
		[HttpGet]
		public IActionResult Delete(int? id)
		{
			if (id is null)
				return BadRequest();
			var employee = _employeeService.GetEmployeeById(id.Value);

			if (employee is null)
				return NotFound();
			return View(employee);

		}
		[HttpPost]
		public IActionResult Delete(int id)
		{
			var message = string.Empty;
			try
			{
				var deleted = _employeeService.DeleteEmployee(id);

				if (deleted)
					return RedirectToAction(nameof(Index));

				message = "an error has occured during deleting the employee  :( ";
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);

				message = _environment.IsDevelopment() ? ex.Message : "an error has occured during deleting the employee  :( ";

			}

			ModelState.AddModelError(string.Empty, message);
			return RedirectToAction(nameof(Index));

		}
		#endregion

	}
}
