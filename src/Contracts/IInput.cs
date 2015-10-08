using BattleField.Common;

public interface IInput
{
    Coordinates GetTargetCoordinates();

    string GetNameInput(string player);
}
