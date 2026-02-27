using ETLProject.Core.Application.Interfaces;
using ETLProject.Core.Domain.Entities;
using ETLProject.Core.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETLProject.Core.Application.Services
{
    public class CityService : GenericService<City>, ICityService
    {
        private ICityRepository _repo;
        public CityService(ICityRepository repo) : base(repo) 
        {
            _repo = repo;
        }

        public IQueryable<City> GetAllQuery()
        {
            try
            {
                var cities = _repo.GetAllQuery().Include(c => c.Country).AsQueryable() ;

                if (cities != null)
                {
                    return cities;
                }

                Console.WriteLine($"no se encontrarion ciudades en la base de datos");
                return null!;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener enridades", ex);
            }

        }
    }
}
