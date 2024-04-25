using System;
using Domain.Entities;

namespace Core.Contracts.Persistence;

public interface IToDoListRepository {
    Task<ToDoList> CreateToDoList(ToDoList toDoList);
    Task<List<ToDoList>> GetToDoLists();
    Task<ToDoList> UpdateToDoList(int toDoListId, string title);
    Task<bool> DeletToDoList(int todoListId);
}
