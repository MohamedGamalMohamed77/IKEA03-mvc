using AutoMapper;
using LinkDev.IKEA3.BLL.CustomModels.Departments;
using LinkDev.IKEA3.BLL.CustomModels.Employees;
using LinkDev.IKEA3.BLL.Services.Departments;
using LinkDev.IKEA3.BLL.Services.Employees;
using LinkDev.IKEA3.DAL.Models.Departments;
using LinkDev.IKEA3.DAL.Models.Employees;
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
		private readonly IMapper _mapper;
		private readonly IWebHostEnvironment _environment;
		

		public EmployeeController(IEmployeeService employeeService,
			ILogger<EmployeeController> logger,
			IMapper mapper,
			IWebHostEnvironment environment)
		{
			_logger = logger;
			_environment = environment;
			_employeeService = employeeService;
		    _mapper=mapper;
		}
		#endregion

		#region Index
		[HttpGet]
		public IActionResult Index(string search)
		{
			var employee = _employeeService.GetEmployees(search);
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
        public IActionResult Create(EmployeeViewModel employee)
		{
			if (ModelState.IsValid)
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
                };

                var result = _employeeService.CreatedEmployee(createdEmployee) > 0;
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

				message = _environment.IsDevelopment() ? ex.Message : "an error has occured during updating the employee  :( ";

			}

            return Redirect(nameof(Index));
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

			return View(new UpdatedEmployeeDto()
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
        public IActionResult Edit([FromRoute] int id, EmployeeViewModel employee)
		{
			if (!ModelState.IsValid)
				return View(employee);
			var message = string.Empty;
			try
			{
				var updatedEmployee=new UpdatedEmployeeDto() 
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
                };
				
				var result = _employeeService.UpdatedEmployee(updatedEmployee) > 0;

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
		
		[HttpPost]
        [ValidateAntiForgeryToken]
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
