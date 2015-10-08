namespace Battlefield.Logic.Contracts
{
    using Common;

    public interface IInput
    {
        Coordinates GetTargetCoordinates();

        string GetNameInput(string player);
    }
}
