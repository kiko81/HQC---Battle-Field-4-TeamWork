namespace Battlefield.Logic.GameObjects.Bombs
{
    using System;

    public static class BombFactory
    {
        public static Bomb CreateBomb(int bombType)
        {
            switch (bombType)
            {
                case 1:
                    return SingleBomb.Instance;
                case 2:
                    return DoubleBomb.Instance;
                case 3:
                    return TripleBomb.Instance;
                case 4:
                    return QuadBomb.Instance;
                case 5:
                    return QuintBomb.Instance;
                case 6:
                    return HorizontalBomb.Instance;
                case 7:
                    return VerticalBomb.Instance;
                case 8:
                    return XBomb.Instance;
                default:
                    throw new ArgumentException("no bomb there");
            }
        }
    }
}
