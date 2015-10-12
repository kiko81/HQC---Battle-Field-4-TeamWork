namespace Battlefield.Tests.GameObjects
{
    using Logic.Common;
    using Logic.Fields;
    using Logic.GameObjects;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CompositeBombTests
    {
        private CompositeBomb compositeBomb = new CompositeBomb();
        private Cell bomb = new Cell(new Coordinates(2, 2)) { Value = RandomUtils.GenerateRandomNumber(1, 8) };

        [TestMethod]
        public void CompositeBombTestIfSettingWorks()
        {
            var newBomb = new CompositeBomb();

            Assert.AreNotEqual(null, newBomb);
            Assert.AreEqual(0, newBomb.ChainedBombs.Count);
        }

        [TestMethod]
        public void AddTestIfSettingWorks()
        {
            this.compositeBomb.Add(this.bomb);

            Assert.AreSame(this.bomb, this.compositeBomb.ChainedBombs[0]);
        }

        [TestMethod]
        public void TestIfChainReactionReturnsAtLeastOneBombExploded()
        {
            var field = new Field(10, 20);
            this.compositeBomb.Add(this.bomb);
            var bombsExploded = this.compositeBomb.ChainReact(field);

            Assert.IsTrue(bombsExploded > 0);
        }
    }
}