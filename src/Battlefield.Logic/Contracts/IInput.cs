namespace Battlefield.Logic.Contracts
{
    using Battlefield.Logic.Common;

    public interface IInput
    {
        Coordinates GetTargetCoordinates();

        string GetNameInput(string player);
    }
}
