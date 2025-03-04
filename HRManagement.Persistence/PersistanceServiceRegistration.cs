using HRManagement.Persistence.DatabaseContext;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using HRManagement.Application.Contracts.Persistance;
using HRManagement.Persistence.Repository;

namespace HRManagement.Persistence;

public static class PersistanceServiceRegistration
{
    public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<HrDatabaseContext>(opts =>
        {
            opts.UseSqlServer(configuration.GetConnectionString("default"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
        services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
        services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
        return services;
    }
}
