using HRManagement.Domain.Common;

namespace HRManagement.Domain;

public class LeaveAllocation : BaseEntity
{

    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
    public LeaveType LeaveType { get; set; }
    public int NumberOfDays { get; set; }
    public string EmployeeId { get; set; }
}
