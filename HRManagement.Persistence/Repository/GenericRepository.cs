using HRManagement.Application.Contracts.Persistance;
using HRManagement.Domain.Common;
using HRManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Persistence.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly HrDatabaseContext _context;
        public GenericRepository(HrDatabaseContext context)
        {
            _context = context;
        }
        public async Task<T> CreateAsync(T entity)
        {
           await  _context.AddAsync(entity);  
           await  _context.SaveChangesAsync(); 
           return entity;  
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();  
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();  
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(it => it.Id == id);       
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;    
            await _context.SaveChangesAsync();  
            return entity;
        }
    }
}
