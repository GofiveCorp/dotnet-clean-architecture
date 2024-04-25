using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Database.Configurations {
    public class ToDoItemConfiguration : IEntityTypeConfiguration<ToDoItem> {
        public void Configure(EntityTypeBuilder<ToDoItem> builder) {
            builder.HasKey(k => k.ToDoItemId);

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Note)
                .HasMaxLength(500);

            builder.Property(p => p.Done)
                .IsRequired()
                .HasColumnType("bool")
                .HasDefaultValue(1);

            builder.Property(p => p.DateCreated)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(p => p.DateUpdated)
                .HasColumnType("datetime");

            builder.HasOne(o => o.ToDoList).WithMany(w => w.ToDoItems)
                .HasForeignKey(o => o.TodoListId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ToDoItems_ToDoLists");

        }
    }
}
