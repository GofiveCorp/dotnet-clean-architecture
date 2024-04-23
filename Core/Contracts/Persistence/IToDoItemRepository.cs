using System;
using Domain.Entities;

namespace Company.ClassLibrary1;

public interface IToDoItemRepository {
    Task<ToDoItem> CreateToDoItem(ToDoItem toDoItem);
    Task<List<ToDoItem>> GetToDoItems(int todoListId);
    Task<ToDoItem> UpdateToDoItem(ToDoItem toDoItem);
    Task<bool> DeleteToDoItem(int todoItemId);
}
