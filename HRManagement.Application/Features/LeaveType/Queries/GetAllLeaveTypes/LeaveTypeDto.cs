﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class LeaveTypeDto
    {
        public string Days { get; set; }
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
