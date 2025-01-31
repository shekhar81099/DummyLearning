using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using testapi.Filters;
using testapi.Services;

namespace testapi.Controllers
{
  
     // Protect all actions in the controller
    public class SuperHeroController : BaseController
    {
        private readonly ILogger<SuperHeroController> _logger;
        private readonly ISuperheroeservice _superheroeservice;
        public SuperHeroController(ISuperheroeservice superheroeservice, ILogger<SuperHeroController> logger)
        {
            _superheroeservice = superheroeservice;
            _logger = logger;

        }

        // [AdminOnlyFilter] // Protect the action
        [HttpGet("GetSuperHeroes")]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
        {
            _logger.LogInformation("Getting SuperHeroes");
                
                // throw new Exception("An error occurred"); // Throws an exception test code

            return Ok( await _superheroeservice.GetSuperHeroes());
        }

        [HttpGet("GetSuperHeroById/{id}")]
        public async Task<ActionResult<SuperHero>> GetSuperHeroById(int id)
        {
            var superHero = await _superheroeservice.GetSuperHeroById(id);

            if (superHero == null)
            { 
                return NotFound("SuperHero not found");
            }
            return Ok(superHero);
        }

        [HttpPost("AddSuperHeroes")]
        public async Task<ActionResult<List<SuperHero>>> AddSuperHeroes(SuperHero superHero)
        {

            return Ok(await _superheroeservice.AddSuperHeroes(superHero));
        }
        [HttpPut("UpdateSuperHero")]
        public async Task<ActionResult<SuperHero>> UpdateSuperHero(int id, SuperHero superHero)
        {
            var superHeroToUpdate =await _superheroeservice.UpdateSuperHero(id, superHero);

            if (superHeroToUpdate == null)
            {
                return NotFound("SuperHero not found");
            }

            return Ok(superHeroToUpdate);
        }

        [HttpDelete("DeleteSuperHero")]
        public async Task<ActionResult<List<SuperHero>>> DeleteSuperHero(int id)
        {
            var superHeroes = await _superheroeservice.DeleteSuperHero(id);

            if (superHeroes == null)
            {
                return NotFound("SuperHero not found");
            }



            return Ok(superHeroes);
        }


    }
}