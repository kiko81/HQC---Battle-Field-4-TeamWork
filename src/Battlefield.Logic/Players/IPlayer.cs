namespace Battlefield.Logic.Players
{
    using Battlefield.Logic.Fields;

    public interface IPlayer
    {
        bool ChainReactionEnabled { get; set; }
        IField Field { get; }
        string Name { get; }
        int NumberOfBombs { get; set; }
        int ShotCount { get; set; }

        int TakeAShot();
    }
}