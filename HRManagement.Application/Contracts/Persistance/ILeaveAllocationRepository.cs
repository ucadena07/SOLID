using HRManagement.Domain;

namespace HRManagement.Application.Contracts.Persistance;

public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
{
    Task<LeaveAllocation> GetLeaveAllocaitonWithDetailsAsync(int id);
    Task<List<LeaveAllocation>> GetLeaveAllocationWithDetailsAsync();
    Task<List<LeaveAllocation>> GetLeaveAllocationWithDetailsAsync(string userId);
    Task<bool> AllocationExists(string userId, int leaveTypeId, int period);
    Task AddAllocations(List<LeaveAllocation> allocations);
    Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId);
}
