namespace BattleField
{
    using System;

    using Fields;
    using OutputProviders;

    using Players;

    public class Engine
    {
        private bool isGameOver;

        public Engine(Player player1, Player player2)
        {
            this.Player1 = player1;
            this.Player2 = player2;
            this.isGameOver = false;
        }

        private Player Player1 { get; set; }

        private Player Player2 { get; set; }

        public void Start(Player currentPlayer)
        {
            this.PrintField(currentPlayer.Field);

            while (!isGameOver)
            {
                this.UpdateGame(currentPlayer);
                if (!isGameOver)
                {
                    currentPlayer = this.ChangePlayer(currentPlayer);                    
                }
            }

            ConsoleOutput.WinningMessage(currentPlayer.Name, currentPlayer.ShotCount);
        }

        private void PrintField(Field field)
        {
            ConsoleOutput.Print(field.ToString());
        }

        private void UpdateGame(Player currentPlayer)
        {
            while (true)
            {
                var field = currentPlayer.Field.Grid;
                ConsoleOutput.Print(string.Format("{0} on turn", currentPlayer.Name));
                var minesDetonated = currentPlayer.TakeAShot(field);
                currentPlayer.NumberOfBombs -= minesDetonated;
                ConsoleOutput.Print(currentPlayer.Field.ToString());
                ConsoleOutput.PrintRoundSummary(minesDetonated);
                currentPlayer.ShotCount++;

                if (currentPlayer.NumberOfBombs == 0)
                {
                    this.isGameOver = true;
                    break;
                }
                if (minesDetonated == 0)
                {
                    break;
                }

                // TODO
                // here more logic for conditions for bonuses and changing players
                // if sth - no break - current player continues
                // else if - current player continues with enhancement shot (e.g. chain reaction enabled for 1 shot)
                // else sth else - break and swap players
                // else .......
            }
        }

        private Player ChangePlayer(Player currentPlayer)
        {
            return currentPlayer == this.Player1 ? this.Player2 : this.Player1;
        }
    }
}
