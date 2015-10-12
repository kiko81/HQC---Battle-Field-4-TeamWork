namespace Battlefield.Tests.InputProviders
{
    using Logic.InputProviders;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ConsoleInputTests
    {
        [TestMethod]
        public void ConsoleInputTestIfSettingWorks()
        {
            var newConsoleInput = new ConsoleInput(10);

            Assert.IsTrue(newConsoleInput != null);
        }

        [Ignore]
        public void GetSizeInputTestIfSettingWorks()
        {
            Assert.Fail();
        }

        [Ignore]
        public void GetTargetCoordinatesTestIfSettingWorks()
        {
            Assert.Fail();
        }

        [Ignore]
        public void GetNameInputTestIfSettingWorks()
        {
            Assert.Fail();
        }
    }
}