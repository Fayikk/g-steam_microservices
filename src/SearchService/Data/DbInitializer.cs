using System.Text.Json;
using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Data;


public class DbInitializer{
    public static async Task InitDb(WebApplication app){
        await DB.InitAsync("SearchGameDb",MongoClientSettings.FromConnectionString(app.Configuration.GetConnectionString("MongoDbConnection")));


        await DB.Index<GameItem>()
            .Key(x=>x.Title,KeyType.Text)
            .Key(x=>x.Description,KeyType.Text)
            .CreateAsync();

        var count = await DB.CountAsync<GameItem>();

        using var scope = app.Services.CreateScope();
        // var httpClient = scope.ServiceProvider.GetRequiredService<AuctionSvcHttpClient>();
        // var items = await httpClient.GetItemsForSearchDb();
        // Console.WriteLine(items.Count + "returned from the auction service");
        // if (items.Count > 0)
        // {
        //     await DB.SaveAsync(items);
        // }
    }
}
