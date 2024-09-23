using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA3.BLL.CustomModels.Employees
{
	public class EmployeeDetailsDto
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public int? Age { get; set; }
		public string? Address { get; set; }
		[DataType(DataType.Currency)]
		public decimal Salary { get; set; }
		[DataType(DataType.EmailAddress)]
		public string? Email { get; set; }
		public DateOnly HiringDate { get; set; }
		public string? PhoneNumber { get; set; }

		[Display(Name = "Is Active")]
		public bool IsActive { get; set; }
		public string EmployeeType { get; set; } = null!;
		public string Gender { get; set; } = null!;
        #region Adminstration
        public int CreatedBy { get; set; }
        public int LastModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }//this is the date of create the record 
        public DateTime LastModifiedOn { get; set; }

        #endregion


    }
}
