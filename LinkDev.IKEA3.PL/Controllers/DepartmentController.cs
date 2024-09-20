using LinkDev.IKEA3.BLL.CustomModels.Departments;
using LinkDev.IKEA3.BLL.Services.Departments;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.IKEA3.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
       

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;

        }
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();
            return View(departments);
        }
       

    }
}
