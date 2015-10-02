namespace BattleField.Common
{
    using System.Threading;

    public static class Constants
    {
        public const int EmptyCell = 0;
        public const int DetonatedCell = -1;

        public const int BombDownLeftRange = -2;
        public const int BombUpRightRange = 2;
        public const int DetonationSpot = 1;

        public const int MinFieldSize = 5;
        public const int MaxFieldSize = 20;
        public const int MinimumPercentageOfBombs = 15;

        public static readonly int[,] NoBomb =
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 }
        };

        public static readonly int[,] SingleBomb =
        {
            { 0, 0, 0, 0, 0 },
            { 0, 1, 0, 1, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 1, 0, 1, 0 },
            { 0, 0, 0, 0, 0 }
        };

        public static readonly int[,] DoubleBomb =
        {
            { 0, 0, 0, 0, 0 },
            { 0, 1, 1, 1, 0 },
            { 0, 1, 1, 1, 0 },
            { 0, 1, 1, 1, 0 },
            { 0, 0, 0, 0, 0 }
        };

        public static readonly int[,] TripleBomb =
        {
            { 0, 0, 1, 0, 0 },
            { 0, 1, 1, 1, 0 },
            { 1, 1, 1, 1, 1 },
            { 0, 1, 1, 1, 0 },
            { 0, 0, 1, 0, 0 }
        };

        public static readonly int[,] QuadBomb =
        {
            { 0, 1, 1, 1, 0 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 0, 1, 1, 1, 0 }
        };

        public static readonly int[,] QuintBomb =
        {
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 }
        };
    }
}
