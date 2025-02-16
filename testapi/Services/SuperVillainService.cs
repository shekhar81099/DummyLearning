using Microsoft.EntityFrameworkCore;
using testapi.Data;
using testapi.Helper;

namespace testapi.Services
{
    public class SuperVillainService : ISuperVillainService
    {
        private readonly DataContext _context;
        private readonly ILogger<SuperVillainService> _logger;

        public SuperVillainService(DataContext context, ILogger<SuperVillainService> logger)
        {
            "this SuperVillainService instance Created".Print();
            _context = context;
            _logger = logger;
        }

        public async Task<List<SuperVillains>> GetSuperVillains()
        {
            return await _context.SuperVillains.ToListAsync();
        }

    }
}