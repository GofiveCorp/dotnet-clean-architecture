using Core.Contracts.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.ToDoLists.Commands.DeleteToDoList {
    public class DeleteToDoListHandler : IRequestHandler<DeleteToDoListCommand, bool> {
        private readonly IToDoListRepository _toDoListRepository;

        public DeleteToDoListHandler(IToDoListRepository toDoListRepository) {
            _toDoListRepository = toDoListRepository;
        }

        public async Task<bool> Handle(DeleteToDoListCommand request, CancellationToken cancellationToken) {
            var response = await _toDoListRepository.DeletToDoList(request.ToDoListId);
            return response;
        }
    }
}
