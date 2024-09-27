using LinkDev.IKEA3.DAL.Models.Departments;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA3.DAL.Presistance.Data.Configurations.Departments
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.Id).UseIdentityColumn(10, 10);
            builder.Property(d => d.Code).HasColumnType("varchar").HasMaxLength(20).IsRequired();
            builder.Property(d => d.Name).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(d => d.CreatedOn).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(d => d.LastModifiedOn).HasComputedColumnSql("GETDATE()");

            builder.HasMany(D => D.employees)
                    .WithOne(E => E.Department)
                    .HasForeignKey(E => E.DepartmentId)
                    .OnDelete(DeleteBehavior.SetNull);


        }
    }
}
