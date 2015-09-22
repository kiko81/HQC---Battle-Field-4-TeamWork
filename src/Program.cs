namespace BattleField
{
    using System;

    using Common;
    using Fields;
    using GameObjects;
    using InputProviders;

    public class Engine
    {
        public static int Explode(int[,] arr, int n, int x, int y)
        {
            int[,] expl;
            switch (arr[x, y]) // zadava ni koi vid bomba imame
            {
                case 1: expl = new SingleMine().Explosion; break;
                case 2: expl = new DoubleMine().Explosion; break;
                case 3: expl = new TripleMine().Explosion; break;
                case 4: expl = new QuadMine().Explosion; break;
                case 5: expl = new QuintMine().Explosion; break;
                default: throw new ArgumentException("No mine in this field");
            }
            //gyrmi bombata
            int counter = 0;
            for (int i = Constants.BombDownLeftRange; i <= Constants.BombUpRightRange; i++)
            {
                for (int j = Constants.BombDownLeftRange; j <= Constants.BombUpRightRange; j++)
                {
                    if (x + i >= 0 && x + i < n && y + j >= 0 && y + j < n)
                    {
                        if (expl[i + 2, j + 2] == Constants.DetonationField)
                        {
                            if (arr[x + i, y + j] > 0) counter++;
                            arr[x + i, y + j] = Constants.BlownField;
                        }
                    }
                }
            }
            return counter;
        }

        public static int TimeToPlay(int[,] arr, int n)
        {
            int x;
            int y;

            ConsoleInput.GetTargetCoordinates(n, out x, out y);

            if (arr[x, y] <= 0)
            {
                Console.WriteLine("No Bomb there");
                return 0;
            }

            return Explode(arr, n, x, y);
        }

        public static void InitiateGame()
        {
            Console.Write("Welcome to \"Battle Field\" game.\nEnter battle field size: n = ");

            int fieldSize = ConsoleInput.GetSizeInput();

            int[,] mineField = new int[fieldSize, fieldSize];
            var field = new Field(mineField);
            var minimumMines = Constants.MinimumPercentageOfMines * fieldSize * fieldSize / 100;
            Random rand = new Random(); //vhoid i inicializaciq na n i matricata;
            int mineNumber = rand.Next(minimumMines, minimumMines * 2 + 1);
            for (int i = 0; i < mineNumber; i++) // randomizirane na minite i postavqneto im iz poleto
            {
                int x = rand.Next(0, fieldSize);
                int y = rand.Next(0, fieldSize);
                while (mineField[x, y] != 0)
                {
                    x = rand.Next(0, fieldSize);
                    y = rand.Next(0, fieldSize);
                }
                mineField[x, y] = rand.Next(1, 6);
            }

            Console.WriteLine(field.GenerateFieldSymbols());
            //PrintField(arr, n);
            int bombsDetonated = 0;
            while (mineNumber > 0)
            {
                int tmp = TimeToPlay(mineField, fieldSize);
                mineNumber -= tmp;
                Console.WriteLine(field.GenerateFieldSymbols());
                Console.WriteLine("Mines Blown this round: {0}", tmp);
                bombsDetonated++;
            }
            Console.WriteLine("Game over! Number of bombs detonated:{0}", bombsDetonated);
        }

        static void Main()
        {
            InitiateGame();
        }
    }
}

