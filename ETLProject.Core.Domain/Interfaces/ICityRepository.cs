using ETLProject.Core.Application.Interfaces;
using ETLProject.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETLProject.Core.Domain.Interfaces
{
    public interface ICityRepository : IGenericRepository<City>
    {
        IQueryable<City> GetAllQuery();
    }
}
