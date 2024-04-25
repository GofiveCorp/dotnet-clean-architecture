using Domain.Common;

namespace Domain.Entities
{
    public class ToDoList : BaseEntity {
        public int ToDoListId { get; set; }
        public string Title { get; set; }
        public ICollection<ToDoItem> ToDoItems{ get; set; } = [];
    }
}