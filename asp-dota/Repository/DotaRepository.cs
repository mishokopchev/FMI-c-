using System;
using aspdota.Data;
using aspdota.Models;
using Microsoft.Extensions.Logging;

namespace aspdota.Repository
{
    public class DotaRepository :IDotaRepository
    {
        private DotaContext _dbContext;
        private ILogger _logger;

        public DotaRepository()
        {
            
        }

        public void Persist(DotaEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
