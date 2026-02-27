using ETLProject.Core.Domain.Entities;
using ETLProject.Core.Domain.Interfaces;
using ETLProject.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETLProject.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ETLDbContext context) : base(context)
        {
        }

        public IQueryable<Category> GetAllQuery()
        {
            return _context.Set<Category>().AsQueryable();
        }
    }
}
