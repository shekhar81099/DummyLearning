using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using testapi.Helper;

namespace testapi.Controllers
{

    public class TestThread : BaseController
    {
        private readonly ILogger<TestThread> _logger;

        public TestThread(ILogger<TestThread> logger)
        {
            "TestHTread COntrooler Test".Print();
            _logger = logger;
        }

        [HttpGet("test1")]
        public async Task<string> Get()
        {
            await Task.Delay(5000);
            return "OK";
        }

        [HttpGet("test2")]
        public async Task<string> Get1()
        {
            await Task.Delay(5000);
            return "POKE";
        }
    }
}
