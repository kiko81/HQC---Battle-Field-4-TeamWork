namespace Battlefield.Tests.GameObjects
{
    using Logic.GameObjects;
    using Logic.GameObjects.Bombs;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ExplosionStrategyTests
    {
        private readonly ExplosionStrategy strategy = new ExplosionStrategy(5);
        private readonly Bomb bomb = QuintBomb.Instance;

        [TestMethod]
        public void ExplosionStrategyTestIfSettingWorks()
        {
            var newStrategy = new ExplosionStrategy(5);
            Assert.AreEqual(this.strategy.Bomb.GetType(), newStrategy.Bomb.GetType());
        }

        [TestMethod]
        public void TestIfExplosionReturnsCorrectValue()
        {
            Assert.AreEqual(this.strategy.GetExplosion(), this.bomb.Explode());
        }

        [TestMethod]
        public void GetInvertedExplosionTestIfSettingWorks()
        {
            var invertedBomb = new Invertable(this.bomb);
            Assert.AreEqual(this.strategy.GetInvertedExplosion(), invertedBomb.InvertExplosion());
        }
    }
}