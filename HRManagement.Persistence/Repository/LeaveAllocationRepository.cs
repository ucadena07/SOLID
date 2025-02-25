using HRManagement.Application.Contracts.Persistance;
using HRManagement.Domain;
using HRManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Persistence.Repository
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
        {
        }

        public async Task AddAllocations(List<LeaveAllocation> allocations)
        {
           await _context.AddRangeAsync(allocations);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
        {
            return await _context.LeaveAllocations.AnyAsync(it => it.EmployeeId == userId && it.LeaveTypeId == leaveTypeId && it.Period == period);
        }

        public async Task<LeaveAllocation> GetLeaveAllocaitonWithDetailsAsync(int id)
        {
            var returnObj = await _context.LeaveAllocations.Include(it => it.LeaveType).FirstOrDefaultAsync(it => it.Id == id);
            return returnObj;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetailsAsync()
        {
            var returnObj = await _context.LeaveAllocations.Include(it => it.LeaveType).ToListAsync();
            return returnObj;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetailsAsync(string userId)
        {
            var returnObj = await _context.LeaveAllocations.Where(it => it.EmployeeId == userId).Include(it => it.LeaveType).ToListAsync();
            return returnObj;
        }

        public async Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
        {
            return await _context.LeaveAllocations.FirstOrDefaultAsync(it => it.EmployeeId == userId && it.LeaveTypeId == leaveTypeId);   
        }
    }
}
