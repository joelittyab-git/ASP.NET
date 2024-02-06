using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Entities;

namespace GameStore.Repositries
{
    public class InMemoryService : IGamesRepository
    {
        private readonly List<Game> games = [
            new Game(){
                Id = 1,
                Name = "Street Fghter II",
                Genre = "Action",
                Price = 19.99m,
                ReleaseDate = new DateTime(1999, 2 , 1),
                ImageUri = "https://placehold.co/100"
            },new Game(){
                Id = 2,
                Name = "City Skylines II",
                Genre = "Creative",
                Price = 79.99m,
                ReleaseDate = new DateTime(2023, 10 , 1),
                ImageUri = "https://placehold.co/100"
            },new Game(){
                Id = 3,
                Name = "Final Fantasy XIV",
                Genre = "Role Playing",
                Price = 69.99m,
                ReleaseDate = new DateTime(2010, 12 , 3),
                ImageUri = "https://placehold.co/100"
            },new Game(){
                Id = 4,
                Name = "FIFA 2022",
                Genre = "Sports",
                Price = 89.99m,
                ReleaseDate = new DateTime(2022, 12 , 1),
                ImageUri = "https://placehold.co/100"
            }
        ];

        public IEnumerable<Game> GetAll(){
            return games;
        }

        public Game? Get(int id){
            return games.Find((Game g) => g.Id == id);
        }

        public void Create(Game game){
            game.Id = games.Count+1;
            games.Append(game);
        }

        public void Update(Game updatedgame){
            int index = games.FindIndex(game=>game.Id==updatedgame.Id);
            games[index] = updatedgame;
        }

        public void Delete(int id){
            int index = games.FindIndex(game=>game.Id==id);
            games.RemoveAt(index);
        }
    }
}