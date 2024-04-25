using System;
using Domain.Entities;
using MediatR;

namespace Core.Features.ToDoLists.Commands.CreateToDoList;

public class CreateToDoListCommand : IRequest<ToDoList> {
    public string Title { get; set; }
}
