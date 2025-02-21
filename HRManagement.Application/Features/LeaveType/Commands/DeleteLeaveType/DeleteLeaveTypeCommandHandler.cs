using AutoMapper;
using HRManagement.Application.Contracts.Persistance;
using HRManagement.Application.Exceptions;
using HRManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.LeaveType.Commands.DeleteLeaveType
{

    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommnad, Unit>
    {


        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<Unit> Handle(DeleteLeaveTypeCommnad request, CancellationToken cancellationToken)
        {

            var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);
            if (leaveTypeToDelete == null) throw new NotFoundException(nameof(LeaveType),request.Id);

            await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);

            return Unit.Value;
        }
    }
}
