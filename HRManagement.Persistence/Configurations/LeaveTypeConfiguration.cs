﻿using HRManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Persistence.Configurations
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData(
                  new LeaveType
                  {
                      Id = 1,
                      Name = "Vacation",
                      DefaultDays = 10,
                      DateCreated = DateTime.Now,
                  });

            builder.Property(it => it.Name).IsRequired().HasMaxLength(100);  

        }
    }
}
