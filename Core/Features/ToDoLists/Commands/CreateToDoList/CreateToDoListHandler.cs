using System;
using Company.ClassLibrary1;
using Core.Contracts.Persistence;
using Domain.Entities;
using MediatR;

namespace Core.Features.ToDoLists.Commands.CreateToDoList;

public class CreateToDoListHandler : IRequestHandler<CreateToDoListCommand, int> {
    private readonly IToDoListRepository _toDoListRepository;
    public CreateToDoListHandler(IToDoListRepository toDoListRepository) {
        _toDoListRepository = toDoListRepository;
    }

    public async Task<int> Handle(CreateToDoListCommand request, CancellationToken cancellationToken) {
        var toDoListModel = new ToDoList() {
            Title = request.Title,
            Status = (int)ToDoListStatus.InProgress,
            DateCreated = DateTime.UtcNow,
        };
        return await _toDoListRepository.CreateToDoList(toDoListModel);
    }
}
