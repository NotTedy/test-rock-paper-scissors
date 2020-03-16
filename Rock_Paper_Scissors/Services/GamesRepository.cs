using System;
using System.Collections.Generic;
using System.Linq;
using Rock_Paper_Scissors.Models;


namespace Rock_Paper_Scissors.Services
{
    public class GamesRepository
    {
        // list of games
        List<Game> _games;


        // counter for games
        int idInt = 1;

        /// <summary>
        /// Contains all the saved games
        /// </summary>
        public GamesRepository()
        {
            _games = new List<Game>();

            //Game someNewGame = new Game();
            //someNewGame.Id = idInt;
            //idInt++;
            //someNewGame.Player1Name = "Todd";
            //_games.Add(someNewGame);
            

            //Game newGame = new Game();
            //newGame.Id = idInt;
            //idInt++;
            //newGame.Player2Name = "Björn";
            //_games.Add(newGame);
        }


        public List<Game> GetAllGames()
        {
            return _games;
        }

        public Game GetGameById(int id)
        {
            var game = _games.FirstOrDefault(g => g.Id == id);
            return game;
        }

        public Game CreateNewGame(string name)
        {
            Game NewGame = new Game();
            NewGame.Id = idInt;
            idInt++;
            NewGame.Player1Name = name;
            _games.Add(NewGame);

            return NewGame;
        }

        public Game JoinGame(string name, int id)
        {
            var game = _games.FirstOrDefault(g => g.Id == id);

            if (game.Player2Name == null)
            {
                game.Player2Name = name;
            }
            return game;
        }

        public GameResult MakeMove(string name, int id, string move)
        {
            var game = _games.FirstOrDefault(g => g.Id == id);
            GameResult gameResult = new GameResult();


            if (game.Player1Name == name)
            {
                if (game.Player1Move == null)
                {
                    game.Player1Move = move;
                }
            }

            if (game.Player2Name == name)
            {
                if (game.Player2Move == null)
                {
                    game.Player2Move = move;
                }
            }      


            if(game.Player1Move != null && game.Player2Move != null)
            {
                if (game.Player1Move == "Rock" && game.Player2Move == "Scissors")
                {
                    game.Player1State = PlayerState.Win;
                    game.Player2State = PlayerState.Loose;
                    game.Result = GameState.GameDone;
                }
                else if (game.Player1Move == "Paper" && game.Player2Move == "Rock")
                {
                    game.Player1State = PlayerState.Win;
                    game.Player2State = PlayerState.Loose;
                    game.Result = GameState.GameDone;
                }
                else if (game.Player1Move == "Scissors" && game.Player2Move == "Paper")
                {
                    game.Player1State = PlayerState.Win;
                    game.Player2State = PlayerState.Loose;
                    game.Result = GameState.GameDone;
                }
                else if (game.Player1Move == "Rock" && game.Player2Move == "Paper")
                {
                    game.Player1State = PlayerState.Loose;
                    game.Player2State = PlayerState.Win;
                    game.Result = GameState.GameDone;
                }
                else if (game.Player1Move == "Scissors" && game.Player2Move == "Rock")
                {
                    game.Player1State = PlayerState.Loose;
                    game.Player2State = PlayerState.Win;
                    game.Result = GameState.GameDone;
                }
                else if (game.Player1Move == "Paper" && game.Player2Move == "Scissors")
                {
                    game.Player1State = PlayerState.Loose;
                    game.Player2State = PlayerState.Win;
                    game.Result = GameState.GameDone;
                }
                else if (game.Player1Move == "Rock" && game.Player2Move == "Rock")
                {
                    game.Player1State = PlayerState.Tie;
                    game.Player2State = PlayerState.Tie;
                    game.Result = GameState.GameDone;
                }
                else if (game.Player1Move == "Paper" && game.Player2Move == "Paper")
                {
                    game.Player1State = PlayerState.Tie;
                    game.Player2State = PlayerState.Tie;
                    game.Result = GameState.GameDone;
                }
                else if (game.Player1Move == "Scissors" && game.Player2Move == "Scissors")
                {
                    game.Player1State = PlayerState.Tie;
                    game.Player2State = PlayerState.Tie;
                    game.Result = GameState.GameDone;
                }
                else
                {
                    //do nothing, probably doesnt happen
                }

            }
            else
            {
                GameState gameState = GameState.WatingForMove;
                game.Result = gameState;
            }



            if (game.Player1Name != null)
            {
                gameResult.Player1Name = game.Player1Name;

            }
          
            if (game.Player2Name != null)
            {
                gameResult.Player2Name = game.Player2Name;
            }


            if (game.Id != 0)
            {
                gameResult.Id = game.Id;
            }


            if (game.Result == GameState.GameDone)
            {
                gameResult.Result = $"{gameResult.Player1Name} {game.Player1State.ToString()} and " +
                    $"{gameResult.Player2Name} {game.Player2State.ToString()}!" ;
            }
            if (game.Result == GameState.WatingForMove)
            {
                gameResult.Result = "Wating for move!";
            }
            if(game.Result == GameState.GameInitialized)
            {
                gameResult.Result = "Just initialized";
            }

            return gameResult;

        }
    }
}
