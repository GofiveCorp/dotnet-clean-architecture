using Core.Contracts.Repository;
using Domain.Entities;
using Infra.Database.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Database.Repositories {
    public class ToDoListRepository : IToDoListRepository {
        private readonly SqliteDatabaseContext dbContext;

        public ToDoListRepository(SqliteDatabaseContext dbContext) {
            this.dbContext = dbContext;
        }

        public async Task<ToDoList> CreateToDoList(string title) {
            var toDoList = new ToDoList {
                Title = title,
                DateCreated = DateTime.Now,
            };
            await dbContext.ToDoLists.AddAsync(toDoList);
            await dbContext.SaveChangesAsync();
            return toDoList;
        }

        public async Task<bool> DeletToDoList(int todoListId) {
            var todoList = await dbContext.ToDoLists.FirstOrDefaultAsync(f => f.ToDoListId == todoListId);
            if (todoList is null)
                return false;
            dbContext.ToDoLists.Remove(todoList);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<ToDoList>> GetToDoLists() {
            return await dbContext.ToDoLists.AsNoTracking().ToListAsync();
        }

        public async Task<bool> IsUniqueTitle(string title) {
            var duplicate = await dbContext.ToDoLists.AsNoTracking().AnyAsync(a => a.Title.Equals(title));
            return duplicate is false;
        }

        public async Task<ToDoList> UpdateToDoList(int toDoListId, string title) {
            var todoList = await dbContext.ToDoLists.FirstOrDefaultAsync(f => f.ToDoListId == toDoListId);
            if (todoList is null)
                return null;
            todoList.Title = title;
            todoList.DateUpdated = DateTime.Now;
            dbContext.Update(todoList);
            await dbContext.SaveChangesAsync();
            return todoList;
        }
    }
}
