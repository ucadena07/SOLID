using HRManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Application.Contracts.Persistance;

public interface IGenericRepository<T> where T : class
{
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();

}


public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
{

}

public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
{

}

public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
{

}