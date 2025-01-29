using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testapi.Services
{
    public interface ISuperVillainService
    {
        Task<List<SuperVillains>> GetSuperVillains();
    }
}