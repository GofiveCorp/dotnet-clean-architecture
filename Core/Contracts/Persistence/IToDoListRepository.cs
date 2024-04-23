using System;
using Domain.Entities;

namespace Company.ClassLibrary1;

public interface IToDoListRepository {
    Task<ToDoList> CreateToDoList(ToDoList toDoList);
    Task<List<ToDoList>> GetToDoLists();
    Task<List<ToDoList>> UpdateToDoList(ToDoList toDoList);
    Task<bool> DeletToDoList(int todoListId);
}
