namespace Battlefield.Logic.Engines
{
    using Battlefield.Logic.Players;

    public interface IEngine
    {
        bool IsGameOver { get; set; }

        void Start(IPlayer currentPlayer);
    }
}