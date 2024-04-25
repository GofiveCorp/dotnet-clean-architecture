using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.ToDoLists.Commands.DeleteToDoList {
    public class DeleteToDoListCommand : IRequest<bool> {
        public int ToDoListId { get; set; }
    }
}
