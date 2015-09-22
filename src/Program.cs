namespace BattleField
{
    using System;
    using System.Linq;

    using Common;
    using GameObjects;

    public class Engine
    {
        public static void PrintField(int[,] arr, int size)
        {
            Console.Write("  ");

            for (int i = 0; i < size; i++)
            {
                Console.Write(" {0}", i + 1);
            }

            Console.WriteLine();
            Console.Write("  ".PadRight((size+1) * 2 + 1, '-'));

            //for (int i = 0; i < size * 2; i++)
            //{
            //    Console.Write("-");
            //}
            Console.WriteLine();

            for (int i = 0; i < size; i++)
            {
                if (i == 9)
                {
                    Console.Write("{0}|", i + 1);
                }
                else
                {
                    Console.Write("{0}".PadLeft(4, ' ') + "|", i + 1);
                }

                for (int j = 0; j < size; j++)
                {
                    char c;
                    switch (arr[i, j])
                    {
                        case Constants.EmptyField: c = '-'; break;
                        case Constants.BlownField: c = 'X'; break;
                        default: c = (char)('0' + arr[i, j]); break;
                    }
                    Console.Write("{0} ", c);
                }
                Console.WriteLine();
            }
        }

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
            int x = 0, y = 0;
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
                        //if (s.Length > 3)
                        //{
                        //    if (s.ElementAt(3) != ' ')
                        //        Console.WriteLine("Invalid move!");
                        //    else cond = false;
                        //}
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
            int n;
            Console.Write("Welcome to \"Battle Field\" game.\nEnter battle field size: n = ");
            int.TryParse(Console.ReadLine(), out n);
            while (n < 1 || n > 10)
            {
                Console.Write("n is between 1 and 10! Please enter new n = ");
                int.TryParse(Console.ReadLine(), out n);
            }
            int[,] arr = new int[n, n];
            Random ProizvolniChisla = new Random(); //vhoid i inicializaciq na n i matricata;
            int mineNumber = ProizvolniChisla.Next(15 * n * n / 100, 30 * n * n / 100 + 1);
            for (int i = 0; i < mineNumber; i++) // randomizirane na minite i postavqneto im iz poleto
            {
                int x = ProizvolniChisla.Next(0, n);
                int y = ProizvolniChisla.Next(0, n);
                while (arr[x, y] != 0)
                {
                    x = ProizvolniChisla.Next(0, n);
                    y = ProizvolniChisla.Next(0, n);
                }
                arr[x, y] = ProizvolniChisla.Next(1, 6);
            }
            PrintField(arr, n);
            int bombsDetonated = 0;
            while (mineNumber > 0)
            {
                int tmp = TimeToPlay(arr, n);
                mineNumber -= tmp;
                PrintField(arr, n);
                //Console.WriteLine("Mines Blowed this round: {0}",tmp);
                bombsDetonated++;
            }
            Console.WriteLine("Game over! Number of bombs detonated:{0}", bombsDetonated);
        }
    
        static void Main(string[] args)
        {
            InitiateGame();
        }
    }
}

