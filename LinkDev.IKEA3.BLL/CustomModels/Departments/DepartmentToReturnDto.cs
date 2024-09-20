using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA3.BLL.CustomModels.Departments
{
    public class DepartmentToReturnDto
    {
        public int Id { get; set; }
        //public int CreatedBy { get; set; }
        //public int LastModifiedBy { get; set; }
        //public DateTime CreatedOn { get; set; }//this is the date of create the record 
        //public DateTime LastModifiedOn { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public DateOnly CreationDate { get; set; }
    }
}
