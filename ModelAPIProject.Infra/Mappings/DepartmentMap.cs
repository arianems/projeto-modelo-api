﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenAPI.Domain.Entities;

namespace TokenAPI.Infra.Mappings
{
    public class DepartmentMap : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.Id).IsRequired();

            builder.Property(d => d.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasMany(d => d.Employees)
                .WithOne(e => e.Department);
        }
    }
}