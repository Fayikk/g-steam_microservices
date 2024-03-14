using GameService.DTOs;
using GameService.Model;

namespace GameService.Services.GameServices;


public interface IGame_Service 
{
    Task<BaseResponseModel> CreateGame(CreateGameDTO gameDTO);
}