using System;
using aspdota.Models;

namespace aspdota.Adapter
{
    public class GameToGameDTOAdapter : Adapter<GameEntity,GameEntity>
    {
        
        public GameToGameDTOAdapter()
        {
            
        }

        public GameEntity Adapt(GameEntity obj) => throw new NotImplementedException();
    }
}
