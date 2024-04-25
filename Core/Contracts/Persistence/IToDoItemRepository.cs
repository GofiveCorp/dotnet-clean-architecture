using System;
using Domain.Entities;

namespace Company.ClassLibrary1;

public interface IToDoItemRepository {
    Task<ToDoItem> CreateToDoItem(int toDoListId, string title, string note);
    Task<List<ToDoItem>> GetToDoItems(int todoListId);
    Task<ToDoItem> UpdateToDoItem(int toDoItemId, string title, string note, bool isDone);
    Task<bool> DeleteToDoItem(int todoItemId);
}
