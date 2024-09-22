using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA3.BLL.CustomModels.Departments
{
    public class CreatedDepartmentDto
    {
        [Required]
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
        [Display(Name = "Date of creation")]
        public DateOnly CreationDate { get; set; }

    }
}
