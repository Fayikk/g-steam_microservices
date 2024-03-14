using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Consumers;



public class GameCreatedConsumer : IConsumer<AddGame>
{
    private readonly IMapper _mapper;

    public GameCreatedConsumer(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<AddGame> context)
    {
         Console.WriteLine("--> Consuming Auction Created"+context.Message.Id);

            var item = _mapper.Map<GameItem>(context.Message);

            if (item.Title == "Barbie")
            {
                throw new ArgumentException("Cannot sell cars with name of foo");
            }

            await item.SaveAsync();
    }
}