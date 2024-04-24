using System;
using MediatR;

namespace Core.Features.ToDoLists.Commands.CreateToDoList;

public class CreateToDoListCommand : IRequest<int> {
    public string Title { get; set; }
}
