using Core.Contracts.Persistence;
using MediatR;

namespace Core.Features.ToDoLists.Queries.GetToDoLists;

public class GetToDoListHandler : IRequestHandler<GetToDoListQuery, List<Domain.Entities.ToDoList>> {
    private readonly IToDoListRepository _toDoListRepository;
    public GetToDoListHandler(IToDoListRepository toDoListRepository) {
        _toDoListRepository = toDoListRepository;
    }
    public async Task<List<Domain.Entities.ToDoList>> Handle(GetToDoListQuery request, CancellationToken cancellationToken) {
        return await _toDoListRepository.GetToDoLists();
    }
}
