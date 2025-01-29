using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testapi.Services;

namespace testapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperVillainsController : ControllerBase
    {
            private readonly ILogger<SuperVillainsController> _logger;  
            private readonly ISuperVillainService _superVillainService;

            public SuperVillainsController(ISuperVillainService superVillainService, ILogger<SuperVillainsController> logger)
            {
                _superVillainService = superVillainService;
                _logger = logger;
            }
        
            [HttpGet]
            public async Task<IActionResult> GetSuperVillains()
            {
                var superVillains = await _superVillainService.GetSuperVillains();
                return Ok(superVillains);
            }
    }
}