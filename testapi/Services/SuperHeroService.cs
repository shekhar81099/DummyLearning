using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using testapi.Data;
using testapi.Helper;

namespace testapi.Services
{
    public class Superheroeservice : ISuperheroeservice
    {
        private readonly DataContext _context;
        private readonly ILogger<Superheroeservice> _logger;
        public Superheroeservice(DataContext context, ILogger<Superheroeservice> logger)
        {
            "this Superheroeservice instance Created".Print();
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

        public async Task GetAuthorsAndBooks()
        {
            // N+1 problem here if first queries executed 1s and nested queries executed multiple time 
            var authors = await _context.Author.ToListAsync();

            foreach (var author in authors)
            {
                var books = await _context.Book.Where(b => b.AuthorId == author.Id).ToListAsync();
                Console.WriteLine($"Author: {author.Name}");
                foreach (var book in books)
                {
                    Console.WriteLine($"Book: {book.Title}");
                }
            }

            // to fix this problem -- Include loads the data with first queries. 
            // authors = await _context.Author.Include(a => a.Books).ToListAsync();
            authors = await _context.Author.ToListAsync();
        }


        public async Task<List<SuperHero>> GetSuperHeroes()
        {
            try
            {

                //    await  GetAuthorsAndBooks();

                // var res = from sh in _context.SuperHeroes
                //           join sv in _context.SuperVillains
                //           on sh.Id equals sv.Id
                //           select new
                //           {
                //               shId = sh.Id,
                //               shFirstName = sh.FirstName,
                //               shSuperPowers = sh.SuperPowers,
                //               svId = sv.Id,
                //               svFirstName = sv.FirstName,
                //               svSuperPowers = (string)null,
                //           }
                //  ;
                // res = _context.SuperHeroes.Join(_context.SuperVillains, a => a.Id, b => b.Id, (a, b) =>
                // new
                // {
                //     shId = a.Id,
                //     shFirstName = a.FirstName,
                //     shSuperPowers = a.SuperPowers,
                //     svId = b.Id,
                //     svFirstName = b.FirstName,
                //     svSuperPowers = (string)null,
                // });
                // var p = res.ToList();
                // var res =await  _context.SuperHeroes.
                // var res = _context.SuperHeroes.Join(_context.SuperVillains, sh => sh.Id, sv => sv.Id, (sh, sv) => new
                // {
                //     sid = sh.Id,
                //     vid = sv.Id,
                //     heroName = sh.Name,
                //     VilleinName = sv.Name,
                // }).ToList();

                var resLeftJoin = _context.SuperHeroes
                .GroupJoin(
                    _context.SuperVillains,
                    hero => hero.Id,
                    villain => villain.Id,
                    (hero, villainGroup) => new { hero, villainGroup }
                )
                .SelectMany(
                    x => x.villainGroup.DefaultIfEmpty(),
                    (a, x) => new { a.villainGroup }
                // (x, villain) => new
                // {
                //     HeroId = x.hero.Id,
                //     HeroName = x.hero.Name,
                //     VillainId = villain != null ? villain.Id : (int?)null,
                //     VillainName = villain != null ? villain.Name : null
                // }
                ).ToList();

                return await _context.SuperHeroes.Include(a => a.SuperPowers).ToListAsync(); ;

            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<List<SuperHero>> GetSuperHeroes1()
        {
            try
            {
                await transactionExample();

                // does not track changes if occur
                //  await _context.SuperHeroes.AsNoTracking().ToListAsync() ; 
                // IEnumerable<SuperHero> res = _context.SuperHeroes.FromSqlRaw("  ");

                // await res.Where(p => p.Name == "").ExecuteUpdateAsync(p => p.SetProperty(p => p.Name, p => p.FirstName));

                // using (var con = _context.Database.GetDbConnection())
                // {
                //     await con.OpenAsync();
                //     using (var command = con.CreateCommand())
                //     {
                //         command.CommandText = "safsdf";
                //         command.Parameters.Add()
                //         command.CommandType = CommandType.Text;
                //         using (var reader = command.ExecuteNonQuery())
                //         { 

                //         }
                //     }
                // }
                await _context.SuperHeroes.Where(p => p.Name == "").
                ExecuteUpdateAsync(p => p.SetProperty(p => p.Name, p => p.FirstName));

                await _context.SaveChangesAsync();

                return await _context.SuperHeroes.ToListAsync();

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
        public async Task transactionExample()
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                Random r = new Random();
                int v = r.Next(1, 999);
                await _context.SuperHeroes.AddAsync(new SuperHero()
                {
                    FirstName = "Test" + v,
                    LastName = "Test" + v,
                    Place = "Test" + v,
                    SuperPowers = new List<SuperPower>(){
                        new SuperPower(){ SuperPowerName =  "Fire" + v},
                        new SuperPower(){ SuperPowerName =  "Air" + v},
                        new SuperPower(){ SuperPowerName =  "Water" + v},

                    }
                });
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (System.Exception)
            {

                await transaction.RollbackAsync();
            }
        }
    }

}