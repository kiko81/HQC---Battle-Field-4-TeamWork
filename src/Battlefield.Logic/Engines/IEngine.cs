namespace Battlefield.Logic
{
    using Battlefield.Logic.Players;

    public interface IEngine
    {
        void Start(IPlayer currentPlayer);
    }
}