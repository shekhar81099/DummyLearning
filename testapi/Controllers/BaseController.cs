using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace testapi.Controllers
{
    [ApiController]
     
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BaseController : ControllerBase
    {

    }
}