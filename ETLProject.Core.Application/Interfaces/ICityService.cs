using ETLProject.Core.Domain.Entities;


namespace ETLProject.Core.Application.Interfaces
{
    public interface ICityService : IGenericService<City>
    {
        IQueryable<City> GetAllQuery();
    }
}
