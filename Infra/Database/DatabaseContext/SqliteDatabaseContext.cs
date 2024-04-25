using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infra.Database.DatabaseContext {
    public class SqliteDatabaseContext : DbContext {

        public SqliteDatabaseContext(DbContextOptions<SqliteDatabaseContext> options) : base(options) {
        }

        public DbSet<ToDoList> ToDoLists => Set<ToDoList>();
        public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
