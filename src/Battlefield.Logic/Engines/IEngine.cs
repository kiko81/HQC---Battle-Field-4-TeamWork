namespace Battlefield.Logic.Engines
{
    using Battlefield.Logic.Players;

    /// <summary>
    /// Interface for engine classes.
    /// </summary>
    public interface IEngine
    {
        bool IsGameOver { get; set; }

        void Start(IPlayer currentPlayer);
    }
}