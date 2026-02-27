using ETLProject.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETLProject.Core.Application.Interfaces
{
    public interface ICategoryService : IGenericService<Category>
    {
        IQueryable<Category>GetAllQuery();
    }
}
