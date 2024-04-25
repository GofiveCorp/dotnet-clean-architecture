using System;
using Company.ClassLibrary1;
using Core.Contracts.Persistence;
using Domain.Entities;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using MediatR;

namespace Core.Features.ToDoLists.Commands.CreateToDoList;

public class CreateToDoListHandler : IRequestHandler<CreateToDoListCommand, ToDoList> {
    private readonly IToDoListRepository _toDoListRepository;
    public CreateToDoListHandler(IToDoListRepository toDoListRepository) {
        _toDoListRepository = toDoListRepository;
    }

    public async Task<ToDoList> Handle(CreateToDoListCommand request, CancellationToken cancellationToken) {

        var validator = new CreateToDoListValidatior(_toDoListRepository);
        var validatorResult = await validator.ValidateAsync(request, cancellationToken);
        if (validatorResult.IsValid is false) {
            throw new ValidationTestException("Bad request.", validatorResult.Errors);
        }

        var response = await _toDoListRepository.CreateToDoList(request.Title);
        return response;
    }
}
