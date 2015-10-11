namespace Battlefield.Logic.GameObjects.Bombs
{
    public abstract class Bomb
    {
        public abstract int[,] Explode();

        public int[,] InvertBomb(int [,] bomb)
        {
            for (int row = 0; row < bomb.GetLength(1); row++)
            {
                for (int col = 0; col < bomb.GetLength(2); col++)
                {
                    if (bomb[row, col] == 0)
                    {
                        bomb[row, col] = 1;
                    }
                    else if (bomb[row, col] == 1)
                    {
                        bomb[row, col] = 0;
                    }
                }
            }

            return bomb;
        }
    }
}
