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

        public async Task<int> CreateToDoList(ToDoList toDoList) {
            var response = await dbContext.ToDoLists.AddAsync(toDoList);
            await dbContext.SaveChangesAsync();
            return 1;
        }

        public Task<bool> DeletToDoList(int todoListId) {
            throw new NotImplementedException();
        }

        public async Task<List<ToDoList>> GetToDoLists() {
            return await dbContext.ToDoLists.AsNoTracking().ToListAsync();
        }

        public Task<List<ToDoList>> UpdateToDoList(ToDoList toDoList) {
            throw new NotImplementedException();
        }
    }
}
