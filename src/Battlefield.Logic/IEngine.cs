namespace Battlefield.Logic
{
    using Battlefield.Logic.Players;

    public interface IEngine
    {
        IPlayer Player1 { get; set; }
        IPlayer Player2 { get; set; }

        void Start(IPlayer currentPlayer);
    }
}