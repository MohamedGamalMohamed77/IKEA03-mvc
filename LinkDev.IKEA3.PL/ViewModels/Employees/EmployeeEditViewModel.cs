using System.ComponentModel.DataAnnotations;

namespace LinkDev.IKEA3.PL.ViewModels.Employees
{
	public class EmployeeEditViewModel
	{
		public string Name { get; set; } = null!;
		public int? Age { get; set; }
		[DataType(DataType.Currency)]
		public decimal Salary { get; set; }
		[DataType(DataType.EmailAddress)]
		public string? Email { get; set; }
		[Display(Name = "Is Active")]
		public bool IsActive { get; set; }
		
	}
}
