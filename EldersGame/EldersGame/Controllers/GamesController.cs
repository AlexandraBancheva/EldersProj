using EldersGame.Application.Interfaces;
using EldersGame.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace EldersGame.API.Controllers
{
    [ApiController]
    [Route("api/game")]
    public class GamesController : ControllerBase
    {
        private readonly IGamesService _gamesService;

        public GamesController(IGamesService gamesService)
        {
            _gamesService = gamesService;
        }

        [HttpGet]
        [Route(nameof(GetAllGames))]
        public IActionResult GetAllGames() 
        {
            return Ok(_gamesService.GetAllGames());
        }

        [HttpGet]
        [Route(nameof(GetGameById))]
        public IActionResult GetGameById([FromQuery] int id) 
        {
            return Ok(_gamesService.GetGameById(id));
        }

        [HttpPost]
        [Route(nameof(CreateNewGame))]
        public IActionResult CreateNewGame([FromBody] Game game)
        {
            _gamesService.CreateNewGame(game);
            return Ok();
        }

        [HttpPut]
        [Route(nameof(AddGamePrice))]
        public IActionResult AddGamePrice([FromQuery] int id, [FromQuery] double price)
        {
            _gamesService.AddGamePrice(id, price);
            return Ok();
        }
    }
}
