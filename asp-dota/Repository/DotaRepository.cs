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

        public DotaRepository(DotaContext context)
        {
            this._dbContext = context;
        }

        public void Persist(DotaEntity dotaEntity)
        {
            if(dotaEntity != null)
            {
                try
                {
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }




        }
    }
}
