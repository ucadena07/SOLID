﻿using HRManagement.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Domain;

public class LeaveRequest : BaseEntity
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    [ForeignKey("LeaveTypeId")]
    public LeaveType LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public DateTime DateRequested { get; set; }
    public string RequestComments { get; set; }
    public bool Approved { get; set; }
    public int Cancelled { get; set; }
    public string RequestingEmployeeId { get; set; }

}