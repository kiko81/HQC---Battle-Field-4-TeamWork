namespace BattleField
{
    using System;

    using Common;
    using Fields;
    using GameObjects;

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
            int x = 0;
            int y = 0;
            bool cond = true;
            while (cond) //check input
            {
                Console.Write("Please enter coordinates: ");
                string input = Console.ReadLine();
                var coordinates = input.Split(' ');
                if (coordinates.Length == 2)
                {
                    x = int.Parse(coordinates[0]) - 1;
                    y = int.Parse(coordinates[1]) - 1;

                    if (x < 0 || x > n || y < 0 || y > n)
                        Console.WriteLine("Invalid move!");
                    else
                    {
                        cond = false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid move!");
                }

                if (cond == false)
                {
                    if (arr[x, y] <= 0)
                    {
                        cond = true;
                        Console.WriteLine("Invalid move!");
                    }
                }
                    
            }
            return Explode(arr, n, x, y);
        }

        public static void InitiateGame()
        {
            
            int fieldSize;
            Console.Write("Welcome to \"Battle Field\" game.\nEnter battle field size: n = ");
            int.TryParse(Console.ReadLine(), out fieldSize);

            while (fieldSize < Constants.MinFieldSize || fieldSize > Constants.MaxFieldSize)
            {
                Console.Write("n is between 1 and 10! Please enter new n = ");
                int.TryParse(Console.ReadLine(), out fieldSize);
            }
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
                //Console.WriteLine("Mines Blown this round: {0}",tmp);
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

