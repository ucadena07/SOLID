using HRManagement.Domain;

namespace HRManagement.Application.Contracts.Persistance;

public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
{
    Task<LeaveRequest> GetLeaveRequestWithDetailsAsync(int id);
    Task<List<LeaveRequest>> GetLeaveRequestWithDetailsAsync();
    Task<List<LeaveRequest>> GetLeaveRequestWithDetailsAsync(string userId);


}