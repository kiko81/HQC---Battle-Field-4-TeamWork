namespace Battlefield.Logic.GameObjects.Bombs
{
    /// <summary>
    /// Abstract class iplemented by all bombs.
    /// </summary>
    public abstract class Bomb
    {
        /// <summary>
        /// Method returning the explosion pattern.
        /// </summary>
        /// <returns>Pattern of the blast.</returns>
        public abstract int[,] Explode();
    }
}
