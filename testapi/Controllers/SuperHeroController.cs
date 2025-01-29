using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using testapi.Filters;
using testapi.Services;

namespace testapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
     // Protect all actions in the controller
    public class SuperHeroController : ControllerBase
    {
        private readonly ILogger<SuperHeroController> _logger;
        private readonly ISuperHeroService _superHeroService;
        public SuperHeroController(ISuperHeroService superHeroService, ILogger<SuperHeroController> logger)
        {
            _superHeroService = superHeroService;
            _logger = logger;

        }

        [AdminOnlyFilter] // Protect the action
        [HttpGet("GetSuperHeroes")]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
        {
            _logger.LogInformation("Getting SuperHeroes");
                
                // throw new Exception("An error occurred"); // Throws an exception test code

            return Ok( await _superHeroService.GetSuperHeroes());
        }

        [HttpGet("GetSuperHeroById/{id}")]
        public async Task<ActionResult<SuperHero>> GetSuperHeroById(int id)
        {
            var superHero = await _superHeroService.GetSuperHeroById(id);

            if (superHero == null)
            { 
                return NotFound("SuperHero not found");
            }
            return Ok(superHero);
        }

        [HttpPost("AddSuperHeroes")]
        public async Task<ActionResult<List<SuperHero>>> AddSuperHeroes(SuperHero superHero)
        {

            return Ok(await _superHeroService.AddSuperHeroes(superHero));
        }
        [HttpPut("UpdateSuperHero")]
        public async Task<ActionResult<SuperHero>> UpdateSuperHero(int id, SuperHero superHero)
        {
            var superHeroToUpdate =await _superHeroService.UpdateSuperHero(id, superHero);

            if (superHeroToUpdate == null)
            {
                return NotFound("SuperHero not found");
            }

            return Ok(superHeroToUpdate);
        }

        [HttpDelete("DeleteSuperHero")]
        public async Task<ActionResult<List<SuperHero>>> DeleteSuperHero(int id)
        {
            var superHeroes = await _superHeroService.DeleteSuperHero(id);

            if (superHeroes == null)
            {
                return NotFound("SuperHero not found");
            }



            return Ok(superHeroes);
        }


    }
}