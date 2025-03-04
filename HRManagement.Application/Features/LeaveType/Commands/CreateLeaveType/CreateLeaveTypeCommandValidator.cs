using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HRManagement.Application.Contracts.Persistance;

namespace HRManagement.Application.Features.LeaveType.Commands.CreateLeaveType
{
    internal class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} is required.").NotNull().MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 chars");
            RuleFor(p => p.DefaultDays).GreaterThan(1).WithMessage("{PropertyName} cannot exceed 100").LessThan(100).WithMessage("Can not be less than 1");
            RuleFor(p => p).MustAsync(LeaveTypeNameUnique).WithMessage("Leave Type Already Exists");
            _leaveTypeRepository = leaveTypeRepository;
        }

        async Task<bool> LeaveTypeNameUnique(CreateLeaveTypeCommand command, CancellationToken cancellationToken)
        {
            var resp =  await _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
            return !resp;
        }
    }
}
