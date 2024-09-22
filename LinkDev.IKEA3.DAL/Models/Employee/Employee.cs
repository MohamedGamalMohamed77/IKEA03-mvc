using LinkDev.IKEA3.DAL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA3.DAL.Models.Employee
{
	public class Employee : ModelBase
	{
		//[Required]
		//[MaxLength(50,ErrorMessage ="MaxLength of Name is 50 Chars")]
		//[MinLength(5, ErrorMessage = "MinLength of Name is 5 Chars")]
		public string Name { get; set; } = null!;

		//[Range(22,30)]
        public int? Age { get; set; }
		
        public string? Address { get; set; }
		
		//[DataType(DataType.Currency)]
		public decimal Salary { get; set; }

		//[Display(Name ="Hiring Date")]
        public DateOnly HiringDate { get; set; }
		
		
		//[EmailAddress]
        public string? Email { get; set; }

		//[Display(Name ="Phone Number")]
		//[Phone]
		public string? PhoneNumber { get; set; }

        public bool IsActive { get; set; }

        public EmpType EmployeeType { get; set; }

		public Gender Gender { get; set; }

    }
}
