namespace Battlefield.Tests.Fields
{
    using Logic.Common;
    using Logic.Fields;
    using Logic.GameObjects;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FieldTests
    {
        private readonly IField field = new Field(10, 20);

        [TestMethod]
        public void FieldTestIfSettingWorks()
        {
            var newField = new Field(10, 20);

            Assert.AreNotEqual(null, newField);
            Assert.AreEqual(this.field.NumberOfBombs, newField.NumberOfBombs);
            Assert.AreEqual(this.field.Size, newField.Size);
            Assert.AreEqual(false, newField.InvertExplosion);
            Assert.AreEqual(2, newField.Grid.Rank);
        }

        [TestMethod]
        public void TestIfToStringReturnsString()
        {
            Assert.IsTrue(this.field.ToString().GetType() == typeof(string));
            Assert.IsTrue(this.field.ToString().Length > 0);
        }

        [TestMethod]
        public void TestIfExplodeReturnsZeroIfChainReactionEnabled()
        {
            var bomb = new Cell(new Coordinates(2, 2)) { Value = RandomUtils.GenerateRandomNumber(1, 8) };

            var bombsExploded = this.field.Explode(bomb, true, new CompositeBomb());
            Assert.AreEqual(0, bombsExploded);
        }
    }
}