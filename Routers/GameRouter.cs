using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Data.DataTransferObjects;
using GameStore.Properties;
using GameStore.Repositries;
using Microsoft.AspNetCore.Components;
using web.Entities;
using GameStore.Properties.RouterConstants;
namespace GameStore.Routers
{
    public static class GameRouter
    {


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
            ).WithName(GameStoreConstants.GamesGetEndpoint);

            RouteGroup.MapPut(
                "/{id}",
                (IGamesRepository repository,int id, Game game) =>{
                    repository.Update(game);
                    
                    return Results.AcceptedAtRoute(
                        GameStoreConstants.GamesGetEndpoint,
                        new { id = game.Id },
                        game
                    );
                }  
            );

            RouteGroup.MapPost(
                "/",
                (IGamesRepository repository, CreateGameDTO gameDTO) => {
                    
                    repository.Create(gameDTO);

                    return Results.AcceptedAtRoute(
                        GameStoreConstants
                        .GamesGetEndpoint,
                        new {id=repository.GetAll().Count()},
                        repository.Get(repository.GetContainerLength())
                    );
                }
            );

            return RouteGroup;
        }


    }
}