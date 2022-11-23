using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelAPIProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenAPI.Domain.Entities;
using TokenAPI.Domain.Value_Objects;

namespace ModelAPIProject.Infra.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.EmployeeID);

            builder.Property(u => u.Password)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(u => u.EmployeeID)
                .IsRequired();

            builder.HasOne(u => u.Employee)
                .WithOne(e => e.User)
                .HasForeignKey<User>(u => u.EmployeeID);

            builder.OwnsOne(u => u.Email, y =>
            {
                y.Property(x => x.Address)
                .HasMaxLength(90)
                .HasColumnName("Email")
                .IsRequired();
            });
        }
    }
}
