using System;
using Domain.Entities;

namespace Core.Contracts.Persistence;

public interface IToDoListRepository {
    Task<ToDoList> CreateToDoList(string title);
    Task<List<ToDoList>> GetToDoLists();
    Task<ToDoList> UpdateToDoList(int toDoListId, string title);
    Task<bool> DeletToDoList(int todoListId);
    Task<bool> IsUniqueTitle(string title);
}
