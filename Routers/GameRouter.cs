using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Repositries;
using Microsoft.AspNetCore.Components;
using web.Entities;

namespace GameStore.Routers
{
    public static class GameRouter
    {

        private const string GamesGetEndpoint = "GetGames";

        public static RouteGroupBuilder MapGamesEndpoint(this IEndpointRouteBuilder builder){
            //instatntiations
            var RouteGroup = builder.MapGroup("/games");

            RouteGroup.MapGet(
                "/",
                (IGamesRepository repository)=>{
                    return repository.GetAll();
                }
            );

            RouteGroup.MapGet(
                "/{id}",
                (IGamesRepository repository,int id)=>{
                    Game ?game = repository.Get(id);
                    return game is not null ? Results.Ok(game) : Results.NotFound();
                }
            ).WithName(GamesGetEndpoint);

            RouteGroup.MapPut(
                "/{id}",
                (IGamesRepository repository,int id, Game game) =>{
                    repository.Update(game);
                    
                    return Results.AcceptedAtRoute(
                        GamesGetEndpoint,
                        new { id = game.Id },
                        game
                    );
                }  
            );

            RouteGroup.MapPost(
                "/",
                (IGamesRepository repository, Game game) => {
                    
                    repository.Create(game);

                    return Results.AcceptedAtRoute(
                        GamesGetEndpoint,
                        new {id=repository.GetAll().Count()},
                        game
                    );
                }
            );

            return RouteGroup;
        }


    }
}