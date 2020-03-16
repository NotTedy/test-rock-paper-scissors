using System;
namespace Rock_Paper_Scissors.Models
{
    public class Game
    {

        public Game()
        {
        }

        public int Id { get; set; }
        public string Player1Name { get; set; }
        public string Player2Name { get; set; }
        public PlayerState Player1State { get; set; }
        public PlayerState Player2State { get; set; }
        public string Player1Move { get; set; }
        public string Player2Move { get; set; }
        public GameState Result { get; set; }

    }

    public enum GameState
    {
        GameInitialized, GameDone, WatingForMove
    }

    public enum PlayerState
    {
        NothinYet, Win, Loose, Tie
    }

    public class GameResult
    {
        public int Id { get; set; }
        public string Player1Name { get; set; }
        public string Player2Name { get; set; }
        public string Result { get; set; }
    }
}
