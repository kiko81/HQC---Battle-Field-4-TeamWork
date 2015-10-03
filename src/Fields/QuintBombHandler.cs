﻿using BattleField.GameObjects;

public class QuintBombHandler : BombTypeHandlerBase
{
    public override void HandleBombType(int bombType, out int[,] result)
    {
        if (bombType == 5)
        {
            result = new QuintBomb().Explosion;
        }
        else if (_successor != null)
        {
            _successor.HandleBombType(bombType, out result);
        }
        else
        {
            result = new NoBomb().Explosion;
        }
    }
}