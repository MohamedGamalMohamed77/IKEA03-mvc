using LinkDev.IKEA3.DAL.Common;
using System.ComponentModel.DataAnnotations;

namespace LinkDev.IKEA3.PL.ViewModels.Employees
{
	public class EmployeeViewModel
	{
        [MaxLength(50, ErrorMessage = "MaxLength of Name is 50 Chars")]
        [MinLength(5, ErrorMessage = "MinLength of Name is 5 Chars")]
        public string Name { get; set; } = null!;

        [Range(22, 30)]
        public int? Age { get; set; }
        
        //[RegularExpression(@"^[0,9]{1,3}-[a-zA-Z]{4,10}-[a-zA-Z]{5,10}$",
        //    ErrorMessage = "Address must be like 123-Street-City-Country")]
        public string? Address { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [Display(Name = "Hiring Date")]
        public DateOnly HiringDate { get; set; }

        [EmailAddress]

        public string? Email { get; set; }

        [Display(Name = "Phone Number")]
        [Phone]
        public string? PhoneNumber { get; set; }

        public EmpType EmployeeType { get; set; }

        public Gender Gender { get; set; }

        [Display(Name ="DepartmentId")]
        public int? DepartmentId { get; set; }

    }
}