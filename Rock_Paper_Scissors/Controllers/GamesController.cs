using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Rock_Paper_Scissors.Models;
using Rock_Paper_Scissors.Services;
using Action = Rock_Paper_Scissors.Models.Action;

namespace Rock_Paper_Scissors.Controllers
{
    //[Microsoft.AspNetCore.Components.Route("api/[Controller]")] // api/games/getallgames
    public class GamesController : ControllerBase
    {
        private GamesRepository _gamesRepository;

        public GamesController(GamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        [HttpGet("/api/games/allgames")]
        public IActionResult GetGames()
        {
        
            var gamesResult = _gamesRepository.GetAllGames();

            return new JsonResult(gamesResult);
        }


        [HttpGet("/api/games/{id}")]
        public IActionResult GetGame(int id)
        {
            var gameId = _gamesRepository.GetGameById(id);

            if (gameId == null)
            {
                return NotFound();
            }
            return new JsonResult(gameId);
        }

        [HttpPost("/api/games")]
        public IActionResult PostPlayer([FromBody] Player player)
        {

           var gamePlayer1 = _gamesRepository.CreateNewGame(player.Name);

           return new JsonResult(gamePlayer1);
        }

        [HttpPost("/api/games/{id}/join")]
        public IActionResult PlayerJoinGame(int id, [FromBody] Player player)
        {
            var gamePlayer2 = _gamesRepository.JoinGame(player.Name, id);

            return new JsonResult(gamePlayer2);

        }


        [HttpPost("/api/games/{id}/move")]
        public IActionResult PlayerMakeMove(int id, [FromBody] Action moveAction)
        {

            var PlayerMove = _gamesRepository.MakeMove(moveAction.Name, id, moveAction.Move);

            return new JsonResult(PlayerMove);
            
        }
    }
}
