using System;
using aspdota.Models;

namespace aspdota.Repository
{
    public interface IDotaRepository
    {
        void Persist(DotaEntity entity);
    }
}
