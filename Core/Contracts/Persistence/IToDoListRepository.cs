using System;
using Domain.Entities;

namespace Core.Contracts.Persistence;

public interface IToDoListRepository {
    Task<int> CreateToDoList(ToDoList toDoList);
    Task<List<ToDoList>> GetToDoLists();
    Task<List<ToDoList>> UpdateToDoList(ToDoList toDoList);
    Task<bool> DeletToDoList(int todoListId);
}
