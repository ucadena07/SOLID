﻿using AutoMapper;
using HRManagement.Application.Contracts.Logging;
using HRManagement.Application.Contracts.Persistance;
using HRManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using HRManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {

        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<UpdateLeaveTypeCommandHandler> _logger;
        public UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository, IAppLogger<UpdateLeaveTypeCommandHandler> logger)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _logger = logger;
        }
        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {

            var leaveTypeToUpdate = _mapper.Map<Domain.LeaveType>(request);

            await _leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);

            return Unit.Value;
        }
    }
}
