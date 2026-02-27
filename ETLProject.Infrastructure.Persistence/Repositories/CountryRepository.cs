using ETLProject.Core.Application.Interfaces;
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
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {

        public CountryRepository(ETLDbContext context) : base(context)
        {
            
        }

        public IQueryable<Country> GetAllQuery()
        {
            return _context.Set<Country>().AsQueryable();
        }
    }
}
