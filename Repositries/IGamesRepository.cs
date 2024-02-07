using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Data.DataTransferObjects;
using web.Entities;

namespace GameStore.Repositries
{
    public interface IGamesRepository{
        IEnumerable<Game> GetAll();
        Game? Get(int id);
        void Create(Game game);
        void Create(CreateGameDTO gameDTO);
        void Update(Game update);
        void Delete(int id);
        int GetContainerLength();

    }
}