namespace BattleField.Common
{
    public static class Constants
    {
        public const int EmptyCell = 0;
        public const int DetonatedCell = -1;

        public const int BombDownLeftRange = -2;
        public const int BombUpRightRange = 2;
        public const int DetonationSpot = 1;

        public const int MinFieldSize = 1;
        public const int MaxFieldSize = 10;
        public const int MinimumPercentageOfMines = 15;

        public static readonly int[,] SingleMine =
        {
            {0, 0, 0, 0, 0},
            {0, 1, 0, 1, 0},
            {0, 0, 1, 0, 0},
            {0, 1, 0, 1, 0},
            {0, 0, 0, 0, 0}
        };
        public static readonly int[,] DoubleMine =
        {
            {0, 0, 0, 0, 0},
            {0, 1, 1, 1, 0},
            {0, 1, 1, 1, 0},
            {0, 1, 1, 1, 0},
            {0, 0, 0, 0, 0}
        };
        public static readonly int[,] TripleMine =
        {
            {0, 0, 1, 0, 0},
            {0, 1, 1, 1, 0},
            {1, 1, 1, 1, 1},
            {0, 1, 1, 1, 0},
            {0, 0, 1, 0, 0}
        };
        public static readonly int[,] QuadMine =
        {
            {0, 1, 1, 1, 0},
            {1, 1, 1, 1, 1},
            {1, 1, 1, 1, 1},
            {1, 1, 1, 1, 1},
            {0, 1, 1, 1, 0}
        };
        public static readonly int[,] QuintMine =
        {
            {1, 1, 1, 1, 1},
            {1, 1, 1, 1, 1},
            {1, 1, 1, 1, 1},
            {1, 1, 1, 1, 1},
            {1, 1, 1, 1, 1}
        };
    }
}
