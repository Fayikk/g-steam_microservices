using AutoMapper;
using Contracts;
using GameService.Data;
using GameService.DTOs;
using GameService.Entities;
using GameService.Model;
using MassTransit;
using Microsoft.AspNetCore.Http.HttpResults;

namespace GameService.Services.GameServices;


public class Game_Service : IGame_Service
{
    private readonly GameDbContext _context;
    private readonly IMapper _mapper;
    private readonly IPublishEndpoint _publishEndpoint;
    private BaseResponseModel _responseModel;

    public Game_Service(GameDbContext context,IMapper mapper,IPublishEndpoint publishEndpoint,BaseResponseModel responseModel)
    {
        _context = context;
        _mapper = mapper;
        _publishEndpoint = publishEndpoint;
        _responseModel = responseModel;
    }

    public async Task<BaseResponseModel> CreateGame(CreateGameDTO gameDTO)
    {
        var objResult = _mapper.Map<Game>(gameDTO);

        await _context.Games.AddAsync(objResult);
            await _publishEndpoint.Publish(_mapper.Map<AddGame>(objResult));
        
        if (await _context.SaveChangesAsync() > 0)
        {
            _responseModel.IsSuccess = true;
            _responseModel.StatusCode = System.Net.HttpStatusCode.OK;
            _responseModel.Message = "Create process is succesfully";
            return _responseModel;
        }
            _responseModel.IsSuccess = false;
            _responseModel.StatusCode = System.Net.HttpStatusCode.BadRequest;
            return _responseModel;
    }
}