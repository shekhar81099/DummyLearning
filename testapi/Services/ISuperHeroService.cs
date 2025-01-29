using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testapi.Services
{
    public interface ISuperHeroService
    {
        public Task<List<SuperHero>> GetSuperHeroes();
        public Task<SuperHero> GetSuperHeroById(int id);
        public Task<List<SuperHero>> AddSuperHeroes(SuperHero superHero);
        public Task<SuperHero> UpdateSuperHero(int id, SuperHero superHero);
        public Task<List<SuperHero>> DeleteSuperHero(int id);
    }
}