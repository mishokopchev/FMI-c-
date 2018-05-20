using System;
using aspdota.Data;
using aspdota.Models;
using Microsoft.Extensions.Logging;

namespace aspdota.Repository
{
    public class GameRepository : IGameRepository
    {
        private DotaContext _dbContext;
        private ILogger _logger;

        public GameRepository(DotaContext context,ILogger logger)
        {
            _dbContext = context;
            _logger = logger;
        }

        public void Persist(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
