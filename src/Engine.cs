namespace BattleField
{
    using Fields;
    using OutputProviders;

    using Players;

    public class Engine
    {
        public Engine(Player player1, Player player2)
        {
            this.Player1 = player1;
            this.Player2 = player2;
        }

        private Player Player1 { get; set; }

        private Player Player2 { get; set; }

        public void Start(Player currentPlayer)
        {
            this.PrintField(currentPlayer.Field);
            this.UpdateGame(currentPlayer);
        }

        private void PrintField(Field field)
        {
            ConsoleOutput.Print(field.ToString());
        }

        private void UpdateGame(Player currentPlayer)
        {
            var numberOfBombs = currentPlayer.Field.NumberOfBombs;
            var field = currentPlayer.Field.Grid;

            while (numberOfBombs > 0)
            {
                ConsoleOutput.Print(string.Format("{0} on turn", currentPlayer.Name));
                var minesDetonated = currentPlayer.TakeAShot(field);
                numberOfBombs -= minesDetonated;
                ConsoleOutput.Print(currentPlayer.Field.ToString());
                ConsoleOutput.PrintRoundSummary(minesDetonated);
                currentPlayer.ShotCount++;

                // TODO
                // here more logic for conditions for bonuses and changing players
                // if sth - no break - current player continues
                // else if - current player continues with enhancement shot (e.g. chain reaction enabled for 1 shot)
                // else sth else - break and swap players
                // else .......
            }

            ConsoleOutput.WinningMessage(currentPlayer.Name, currentPlayer.ShotCount);
        }
    }
}
