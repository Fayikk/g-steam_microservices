using GameService.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameService.Data;


public class DbInitializer
{
    

    public static void InitDb(WebApplication app){
        using var scope = app.Services.CreateScope();

        SeedData(scope.ServiceProvider.GetService<GameDbContext>());
    }

         private static void SeedData(GameDbContext context)
    {
        context.Database.Migrate();

        if (context.Games.Any())
        {
            Console.WriteLine("Already have data - no need to seed");
            return;
        }

        

        var games = new List<Game>(){
            new Game
            {


                Id = new Guid(),
                Title = "GTA 5",
                Price = 200,
                Description = "Perfect",
                CategoryId = Guid.Parse("bb86051d-9407-45d1-9187-c9d34c0c156d")
                
            },
            new Game
            {
                Id = new Guid(),
                Title = "GTA 4",
                Price = 205,
                              CategoryId = Guid.Parse("bb86051d-9407-45d1-9187-c9d34c0c156d")

            },
            new Game
            {
                Id = new Guid(),
                Title = "Assasin Creed",
                Price = 206,
                Description = "Perfect",

                             CategoryId = Guid.Parse("bb86051d-9407-45d1-9187-c9d34c0c156d")

            },
            new Game
            {
                 Id = new Guid(),
                Title = "NFS High Staks",
                Price = 207,
                Description = "Perfect",

                             CategoryId = Guid.Parse("bb86051d-9407-45d1-9187-c9d34c0c156d")

            },
            new Game
            {
                 Id = new Guid(),
                Title = "Toy Story 2",
                Price = 208,
                Description = "Perfect",

                              CategoryId = Guid.Parse("bb86051d-9407-45d1-9187-c9d34c0c156d")

            },
            new Game
            {
                 Id = new Guid(),
                Title = "Midtown Madness",
                Price = 209,
                Description = "Perfect",

                             CategoryId = Guid.Parse("bb86051d-9407-45d1-9187-c9d34c0c156d")

            },
            new Game
            {
                Id = new Guid(),
                Title = "Midtown Madness 2",
                Price = 210,
                Description = "Perfect",

                             CategoryId = Guid.Parse("bb86051d-9407-45d1-9187-c9d34c0c156d")

            },
            new Game
            {
                 Id = new Guid(),
                Title = "CTR",
                Price = 211,
                Description = "Perfect",

                               CategoryId = Guid.Parse("bb86051d-9407-45d1-9187-c9d34c0c156d")

            },
            new Game
            {
                 Id = new Guid(),
                Title = "Counter Strike Global Offensive",
                Price = 212,
                Description = "Perfect",

                              CategoryId = Guid.Parse("bb86051d-9407-45d1-9187-c9d34c0c156d")

            },
            new Game
            {
                  Id = new Guid(),
                Title = "ABP Reloaded",
                Price = 213,
                Description = "Perfect",

                               CategoryId = Guid.Parse("bb86051d-9407-45d1-9187-c9d34c0c156d")

            }
        };


        context.AddRange(games);

        context.SaveChanges();
    }
}