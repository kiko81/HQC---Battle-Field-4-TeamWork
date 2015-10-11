namespace Battlefield.Logic.Engines
{
    using Players;

    public interface IEngine
    {
        void Start(IPlayer currentPlayer);
    }
}