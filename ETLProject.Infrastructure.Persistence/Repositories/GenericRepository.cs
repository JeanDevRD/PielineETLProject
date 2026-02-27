using ETLProject.Core.Application.Interfaces;
using ETLProject.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETLProject.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        public readonly ETLDbContext _context;
        public GenericRepository(ETLDbContext context) 
        { 
            _context = context;
        }
        public async Task<IEnumerable<TEntity>> LoadAsync(IEnumerable<TEntity> entity)
        {
            try
            {
                _context.Set<TEntity>().AddRange(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading entities: {ex.Message}", ex);
            }
        }

    }
}
