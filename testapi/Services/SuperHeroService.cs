using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using testapi.Data;

namespace testapi.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly DataContext _context;
        private readonly ILogger<SuperHeroService> _logger;
        public SuperHeroService(DataContext context, ILogger<SuperHeroService> logger)
        {
            _context = context;
            _logger = logger;

        }
        // private static List<SuperHero> superHeroes = new List<SuperHero>
        // {
        //     new SuperHero { Id = 1, Name = "Superman", FirstName = "Clark", LastName = "Kent", Place = "Metropolis" },
        //     new SuperHero { Id = 2, Name = "Batman", FirstName = "Bruce", LastName = "Wayne", Place = "Gotham City" },
        //     new SuperHero { Id = 3, Name = "Wonder", FirstName = "Diana", LastName = "Prince", Place = "Themyscira" },
        //     new SuperHero { Id = 4, Name = "Flash", FirstName = "Barry", LastName = "Allen", Place = "Central City" },
        //     new SuperHero { Id = 5, Name = "Green Lantern", FirstName = "Hal", LastName = "Jordan", Place = "Coast City" }
        // };

        public async Task<List<SuperHero>> AddSuperHeroes(SuperHero superHero)
        {
            await _context.SuperHeroes.AddAsync(superHero);
            _logger.LogInformation("SuperHero added");
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>> DeleteSuperHero(int id)
        {
            var superHeroToDelete = await _context.SuperHeroes.FindAsync(id);

            if (superHeroToDelete == null)
            {
                return null;
            }

            _context.SuperHeroes.Remove(superHeroToDelete);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<SuperHero> GetSuperHeroById(int id)
        {
            var superHero = await _context.SuperHeroes.FindAsync(id);
            _logger.LogInformation($"SuperHero found by id: {id}");  
            if (superHero == null)
            {
                return null;
            }
            return superHero;
        }

        public async Task<List<SuperHero>> GetSuperHeroes()
        {
            try
            {
                return   _context.SuperHeroes.ToList();

            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<SuperHero> UpdateSuperHero(int id, SuperHero superHero)
        {
            var superHeroToUpdate = await _context.SuperHeroes.FindAsync(id);

            if (superHeroToUpdate == null)
            {
                return null;
            }

            superHeroToUpdate.Name = superHero.Name;
            superHeroToUpdate.FirstName = superHero.FirstName;
            superHeroToUpdate.LastName = superHero.LastName;
            superHeroToUpdate.Place = superHero.Place;
            await _context.SaveChangesAsync();
            return superHeroToUpdate;
        }
    }
}