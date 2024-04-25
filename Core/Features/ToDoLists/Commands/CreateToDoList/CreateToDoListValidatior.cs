using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Contracts.Persistence;
using FluentValidation;

namespace Core.Features.ToDoLists.Commands.CreateToDoList {
    public class CreateToDoListValidatior : AbstractValidator<CreateToDoListCommand> {
        private readonly IToDoListRepository _toDoListRepository;
        public CreateToDoListValidatior(IToDoListRepository toDoListRepository) {
            _toDoListRepository = toDoListRepository;

            RuleFor(p => p.Title).NotNull().NotEmpty().MaximumLength(200).WithMessage("{PropertyName} is required.");
            RuleFor(p => p).MustAsync(IsUniqueTitle).WithMessage("must be unique.");
        }

        public async Task<bool> IsUniqueTitle(CreateToDoListCommand request, CancellationToken cancellationToken) {
            if (await _toDoListRepository.IsUniqueTitle(request.Title)) {
                return true;
            }
            return false;
        }
    }
}
