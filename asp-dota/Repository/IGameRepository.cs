using System;
using aspdota.Models;

namespace aspdota.Repository
{
    public interface IGameRepository
    {
        void Persist(GameEntity game);

    }
}
