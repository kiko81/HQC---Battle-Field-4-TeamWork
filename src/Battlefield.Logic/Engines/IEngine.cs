namespace Battlefield.Logic.Engines
{
    using Battlefield.Logic.Players;

    public interface IEngine
    {
        void Start(IPlayer currentPlayer);
    }
}