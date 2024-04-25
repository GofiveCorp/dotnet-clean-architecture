using System;
using Company.ClassLibrary1;
using Core.Contracts.Persistence;
using Domain.Entities;
using MediatR;

namespace Core.Features.ToDoLists.Commands.CreateToDoList;

public class CreateToDoListHandler : IRequestHandler<CreateToDoListCommand, ToDoList> {
    private readonly IToDoListRepository _toDoListRepository;
    public CreateToDoListHandler(IToDoListRepository toDoListRepository) {
        _toDoListRepository = toDoListRepository;
    }

    public async Task<ToDoList> Handle(CreateToDoListCommand request, CancellationToken cancellationToken) {
        var toDoListModel = new ToDoList() {
            Title = request.Title,
            DateCreated = DateTime.UtcNow,
        };
        var response = await _toDoListRepository.CreateToDoList(toDoListModel);
        return response;
    }
}
