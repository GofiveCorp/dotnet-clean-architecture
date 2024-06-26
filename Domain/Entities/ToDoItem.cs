using Domain.Common;

namespace Domain.Entities
{
    public class ToDoItem : BaseEntity {
        public int ToDoItemId { get; set; }
        public int TodoListId { get; set; }
        public string Title { get; set; }
        public string Note {get; set; }
        public bool Done { get; set; }
        public virtual ToDoList ToDoList { get; set; }
    }
}