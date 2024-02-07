using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Data.DataTransferObjects;
using web.Entities;

namespace GameStore.Data.Entities
{
    public static class EntityExtensions{
        public static GameDTO AsDTO(this Game game){
            return new GameDTO(){
                Id = game.Id,
                Name = game.Name,
                Genre = [.. game.Genre],
                ReleaseDate = game.ReleaseDate,
                Price = game.Price,
                ImageUri = game.ImageUri
            };
        }
    }
}