namespace Battlefield.Logic.Engines
{
    using System;
    using System.Runtime.CompilerServices;

    using Battlefield.Logic.OutputProviders;
    using Battlefield.Logic.Players;

    public class ConsoleEngine : IEngine
    {
        private const string ChainReactionOn = "Chain Reaction ON";

        private bool isGameOver;
        private IPlayer player1;
        private IPlayer player2;

        public ConsoleEngine(IPlayer player1, IPlayer player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }

        public void Start(IPlayer currentPlayer)
        {
            while (!this.isGameOver)
            {
                ConsoleOutput.Print(string.Format("\n-#- {0}'s turn -#-", currentPlayer.Name));
                ConsoleOutput.Print(currentPlayer.Field.ToString());

                this.UpdateGame(currentPlayer);

                if (!this.isGameOver)
                {
                    currentPlayer = this.ChangePlayer(currentPlayer);                    
                }
            }

            ConsoleOutput.PrintWinningMessage(currentPlayer.Name, currentPlayer.ShotCount);
        }

        // this is templateMethod for our app
        private void UpdateGame(IPlayer currentPlayer)
        {
            while (true)
            {
                if (currentPlayer.ChainReactionEnabled)
                {
                    Console.WriteLine(ChainReactionOn);
                }

                var minesDetonated = currentPlayer.TakeAShot();

                currentPlayer.ShotCount++;
                currentPlayer.NumberOfBombs -= minesDetonated;

                ConsoleOutput.Print(currentPlayer.Field.ToString());
                ConsoleOutput.PrintRoundSummary(minesDetonated);

                if (currentPlayer.NumberOfBombs == 0)
                {
                    this.isGameOver = true;
                    return;
                }

                if (minesDetonated == 0)
                {
                    return;
                }

                currentPlayer.ChainReactionEnabled = true;
                ConsoleOutput.Print(string.Format("\n-#- {0}'s turn -#-", currentPlayer.Name));

                // here more logic for conditions for bonuses and changing players
                // if sth - no break - current player continues
                // else if - current player continues with enhancement shot (e.g. chain reaction enabled for 1 shot)
                // else sth else - break and swap players
                // else .......
            }
        }

        private IPlayer ChangePlayer(IPlayer currentPlayer)
        {
            return currentPlayer == this.player1 ? this.player2 : this.player1;
        }
    }
}