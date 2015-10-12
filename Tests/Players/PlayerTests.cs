namespace Battlefield.Tests.Players
{
    using Logic.Fields;
    using Logic.InputProviders;
    using Logic.Players;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PlayerTests
    {
        private IPlayer player = new Player("Pesho", new Field(10, 20), new ConsoleInput(10));

        [TestMethod]
        public void PlayerTestIfSettingWorks()
        {
            Assert.AreEqual(0, this.player.ShotCount);
            Assert.AreEqual(false, this.player.ChainReactionEnabled);
            Assert.AreEqual("Pesho", this.player.Name);
        }

        [Ignore]
        public void TestIftakingShotNotOnABombReturnsZeroBombsDetonated()
        {
            Assert.Fail();
        }
    }
}