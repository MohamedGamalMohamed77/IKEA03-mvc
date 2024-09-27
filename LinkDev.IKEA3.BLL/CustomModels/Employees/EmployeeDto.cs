using LinkDev.IKEA3.DAL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA3.BLL.CustomModels.Employees
{
	public class EmployeeDto
	{
        public int Id { get; set; }
        public string Name { get; set; } = null!;
		public int? Age { get; set; }
		[DataType(DataType.Currency)]
		public decimal Salary { get; set; }
		[DataType(DataType.EmailAddress)]
		public string? Email { get; set; }
		[Display(Name = "Is Active")]
		public bool IsActive { get; set; }
		public string EmployeeType { get; set; } = null!;
		public string Gender { get; set; } = null!;
		public string Department { get; set; } = null!;


	}
}
