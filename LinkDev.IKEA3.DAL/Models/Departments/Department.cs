using LinkDev.IKEA3.DAL.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA3.DAL.Models.Departments
{
    public class Department : ModelBase
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public DateOnly CreationDate { get; set; }
        
		public virtual ICollection<Employee> employees { get; set; } = new HashSet<Employee>();

		
	}

}
