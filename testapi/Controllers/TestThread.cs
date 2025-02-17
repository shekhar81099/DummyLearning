using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
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
        [ResponseCache(Duration = 60, VaryByQueryKeys = new[] { "*" })] 
        public async Task<int> Get1()
        {
            // await Task.Delay(5000);
            Random n = new();
            int v = n.Next(555, 999);
            return v;
        }
    }
}
