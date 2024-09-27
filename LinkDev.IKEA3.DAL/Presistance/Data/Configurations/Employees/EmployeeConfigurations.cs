using LinkDev.IKEA3.DAL.Common;
using LinkDev.IKEA3.DAL.Models.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA3.DAL.Presistance.Data.Configurations.Employees
{
	public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
	{
		public void Configure(EntityTypeBuilder<Employee> builder)
		{
			builder.Property(E => E.Name).HasColumnType("varchar(50)").IsRequired();
			builder.Property(E => E.Address).HasColumnType("varchar(100)");
			builder.Property(E => E.Salary).HasColumnType("decimal(8,2)");
			builder.Property(E => E.CreatedOn).HasDefaultValueSql("GETUTCDATE()");
			builder.Property(E => E.Gender).
				HasConversion(
				(gender) => gender.ToString(),
				(gender) =>(Gender) Enum.Parse(typeof(Gender), gender)

				);
			builder.Property(E => E.EmployeeType).
				HasConversion(
				(employeeType) => employeeType.ToString(),
				(employeeType) => (EmpType)Enum.Parse(typeof(EmpType), employeeType)

				);


		}



	}
}
