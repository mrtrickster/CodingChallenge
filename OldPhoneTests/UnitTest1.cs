using CodingChallenge;
using NUnit.Framework;

namespace OldPhoneTests
{
    [TestFixture]
    public class ToolsTests
    {
        [Test]
        public void TestOldPhonePad01()
        {
            string result = Tools.OldPhonePad("33#");
            Assert.AreEqual("E", result);
        }

        [Test]
        public void TestOldPhonePad02()
        {
            string result = Tools.OldPhonePad("227*#");
            Assert.AreEqual("B", result);
        }

        [Test]
        public void TestOldPhonePad03()
        {
            string result = Tools.OldPhonePad("4433555 555666#");
            Assert.AreEqual("HELLO", result);
        }

        [Test]
        public void TestOldPhonePad04()
        {
            string result = Tools.OldPhonePad("8 88777444666*664#");
            Assert.AreEqual("TURING", result);
        }
    }
}
