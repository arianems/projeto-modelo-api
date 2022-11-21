using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenAPI.Domain.Entities;
using TokenAPI.Domain.Value_Objects;

namespace TokenAPI.Infra.Mappings
{
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.DateOfBirth)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(e => e.DepartmentID)
                .IsRequired();


            builder.Property(e => e.DateOfAdmission)
                .HasColumnType("date")
                .IsRequired();


            builder.HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentID);

            builder.Navigation(e => e.Department).AutoInclude();

            builder.OwnsOne(e => e.Email, y =>
            {
                y.Property(x => x.Address).HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(90);

                y.HasIndex(y => y.Address);
            });

            builder.OwnsOne(e => e.Name, n =>
            {
                n.Property(n => n.FirstName).HasColumnName(nameof(FullName.FirstName)).IsRequired().HasMaxLength(50);
                n.Property(n => n.MiddleName).HasColumnName(nameof(FullName.MiddleName)).HasMaxLength(50);
                n.Property(n => n.Surname).HasColumnName(nameof(FullName.Surname)).IsRequired().HasMaxLength(50);
                n.HasIndex(n => new { n.FirstName, n.Surname });
            });

        }
    }
}
