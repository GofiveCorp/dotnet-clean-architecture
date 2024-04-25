using Company.ClassLibrary1;
using Core.Contracts.Persistence;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.ToDoLists.Commands.UpdateToDoList {
    public class UpdateToDoListHandler : IRequestHandler<UpdateToDoListCommand, ToDoList> {
        private readonly IToDoListRepository _toDoListRepository;

        public UpdateToDoListHandler(IToDoListRepository toDoListRepository) {
            _toDoListRepository = toDoListRepository;
        }

        public async Task<ToDoList> Handle(UpdateToDoListCommand request, CancellationToken cancellationToken) {
            var response = await _toDoListRepository.UpdateToDoList(request.ToDoListId, request.Title);
            return response;
        }
    }
}
