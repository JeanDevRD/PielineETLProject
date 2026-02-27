using ETLProject.Core.Application.Interfaces;
using ETLProject.Core.Domain.Entities;
using ETLProject.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETLProject.Core.Application.Services
{
    public class CountryServices : GenericService<Country>, ICountryService
    {
        private ICountryRepository _repo;

        public CountryServices(ICountryRepository repo) : base(repo)
        {
            _repo = repo;
        }

        public IQueryable<Country> GetAllQuery()
        {
            try
            {
                var category = _repo.GetAllQuery();

                if (category != null)
                {
                    return category;
                }

                Console.WriteLine($"no se encontró categorias en la base de datos");

                return null!;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener enridades", ex);
            }

        }
    }
}
