using System.Reflection.Metadata.Ecma335;
using GameService.DTOs;
using GameService.Services.GameServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameService.Controllers;


[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    private readonly IGame_Service _gameService;

    public GameController(IGame_Service gameService)
    {
        _gameService = gameService;
    }



    [HttpPost]
    [Authorize]
    public async Task<ActionResult> CreateGame(CreateGameDTO gameDTO)
    {
        var result = await _gameService.CreateGame(gameDTO);
        return Ok(result);
    }
}