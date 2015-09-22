﻿namespace BattleField.GameObjects
{
    public class DoubleMine : Mine
    {
        private readonly int[,] mine =
        {
            {0, 0, 0, 0, 0},
            {0, 1, 1, 1, 0},
            {0, 1, 1, 1, 0},
            {0, 1, 1, 1, 0},
            {0, 0, 0, 0, 0}
        };
        protected override int[,] Explode()
        {
            return this.mine;
        }
    }
}
