using System;
using MediatR;

namespace Core.Features.ToDoLists.Queries.GetToDoLists;

public class GetToDoListQuery : IRequest<List<Domain.Entities.ToDoList>> {

}
