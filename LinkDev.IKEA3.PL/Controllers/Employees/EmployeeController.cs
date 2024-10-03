using LinkDev.IKEA3.BLL.CustomModels.Departments;
using LinkDev.IKEA3.BLL.CustomModels.Employees;
using LinkDev.IKEA3.BLL.Services.Departments;
using LinkDev.IKEA3.BLL.Services.Employees;
using LinkDev.IKEA3.DAL.Models.Departments;
using LinkDev.IKEA3.DAL.Models.Employees;
using LinkDev.IKEA3.PL.ViewModels.Departments;
using LinkDev.IKEA3.PL.ViewModels.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.IKEA3.PL.Controllers.Employees
{
	[Authorize]
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
		public async Task<IActionResult> Index(string search)
		{
			var employee = await _employeeService.GetEmployeesAsync(search);
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel employee)
		{
			if (!ModelState.IsValid)
				return View(employee);

            var message = string.Empty;

			try
			{
				var createdEmployee = new CreatedEmployeeDto()
				{
					Name = employee.Name,
					Age = employee.Age,
					Address = employee.Address,
					HiringDate = employee.HiringDate,
					Salary = employee.Salary,
					Email = employee.Email,
					Gender = employee.Gender,
					EmployeeType = employee.EmployeeType,
					PhoneNumber = employee.PhoneNumber,
					IsActive = employee.IsActive,
					DepartmentId = employee.DepartmentId,
					Image=employee.Image
				};

				var result =await _employeeService.CreatedEmployeeAsync(createdEmployee) > 0;

				if (!result)
				{

					message = "Employee is Created";
					ModelState.AddModelError(string.Empty, message);
					return View(employee); 
				}

			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);

				message = _environment.IsDevelopment() ? ex.Message : "an error has occured during creating the employee  :( ";

                ViewData["message"] = message;
                return RedirectToAction(nameof(Index));
            
			}

            return Redirect(nameof(Index));
        }

		#endregion


		#region Details
		[HttpGet]
		public async Task<IActionResult> Details(int? id)
		{
			if (id is null)
				return BadRequest();

			var employee = await _employeeService.GetEmployeeByIdAsync(id.Value);

			if (employee is null)
				return NotFound();

			return View(employee);
		}
		#endregion

		#region Edit

		[HttpGet]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id is null)
				return BadRequest();

			var employee = await _employeeService.GetEmployeeByIdAsync(id.Value);

			if (employee is null)
				return NotFound();

			return View(new EmployeeViewModel()
			{
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                HiringDate = employee.HiringDate,
                Salary = employee.Salary,
                Email = employee.Email,
                Gender = employee.Gender,
                EmployeeType = employee.EmployeeType,
                PhoneNumber = employee.PhoneNumber,
				IsActive=employee.IsActive,
            });
		}

		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, EmployeeViewModel employee)
		{
			if (!ModelState.IsValid)
				return View(employee);
			var message = string.Empty;
			try
			{
				var updatedEmployee=new UpdatedEmployeeDto() 
				{
					Id=id,
                    Name = employee.Name,
                    Age = employee.Age,
                    Address = employee.Address,
                    HiringDate = employee.HiringDate,
                    Salary = employee.Salary,
                    Email = employee.Email,
                    Gender = employee.Gender,
                    EmployeeType = employee.EmployeeType,
                    PhoneNumber = employee.PhoneNumber,
                    IsActive = employee.IsActive,
                };
				
				var result = await _employeeService.UpdatedEmployeeAsync(updatedEmployee);

				if (result >0)
					return RedirectToAction("Index");
				message = "an error has occured during updating the employee  :( ";

			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);

				message = _environment.IsDevelopment() ? ex.Message : "an error has occured during updating the employee  :( ";
				ViewData["message"] = message;
				return RedirectToAction(nameof(Index));

			}

			return Redirect(nameof(Index));
		}
		#endregion

		#region Delete
		
		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
		{
			var message = string.Empty;
			try
			{
				var deleted = await _employeeService.DeleteEmployeeAsync(id);

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
