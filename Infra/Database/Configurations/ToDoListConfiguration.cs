using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Database.Configurations {
    public class ToDoListConfiguration : IEntityTypeConfiguration<ToDoList> {
        public void Configure(EntityTypeBuilder<ToDoList> builder) {
            builder
                .HasKey(k => k.ToDoListId);

            builder
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
