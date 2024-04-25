using Core.Contracts.Persistence;
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

        public async Task<ToDoList> CreateToDoList(ToDoList toDoList) {
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

        public async Task<ToDoList> UpdateToDoList(int toDoListId, string title) {
            var todoList = await dbContext.ToDoLists.FirstOrDefaultAsync(f => f.ToDoListId == toDoListId);
            if (todoList is null)
                return null;
            todoList.Title = title;
            todoList.DateUpdated = DateTime.UtcNow;
            dbContext.Update(todoList);
            await dbContext.SaveChangesAsync();
            return todoList;
        }
    }
}
