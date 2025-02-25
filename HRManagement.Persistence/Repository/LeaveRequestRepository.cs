using HRManagement.Application.Contracts.Persistance;
using HRManagement.Domain;
using HRManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Persistence.Repository
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(HrDatabaseContext context) : base(context)
        {
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetailsAsync(int id)
        {
            var leaveRequest = await _context.LeaveRequests.Include(it => it.LeaveType).FirstOrDefaultAsync(it => it.Id == id);
            return leaveRequest;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetailsAsync()
        {
            var leaveRequests = await _context.LeaveRequests.Include(it => it.LeaveType).ToListAsync();
            return leaveRequests;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetailsAsync(string userId)
        {
            var leaveRequests = await _context.LeaveRequests.Where(it => it.RequestingEmployeeId == userId).Include(it => it.LeaveType).ToListAsync();
            return leaveRequests;
        }
    }
}
