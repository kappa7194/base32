namespace Albireo.Base32.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EncodeTests : Base32Tests
    {
        [TestMethod]
        public void Vector1()
        {
            Assert.AreEqual(string.Empty, Base32.Encode(AsciiEncoding.GetBytes(string.Empty)));
        }

        [TestMethod]
        public void Vector2()
        {
            Assert.AreEqual("MY======", Base32.Encode(AsciiEncoding.GetBytes("f")));
        }

        [TestMethod]
        public void Vector3()
        {
            Assert.AreEqual("MZXQ====", Base32.Encode(AsciiEncoding.GetBytes("fo")));
        }

        [TestMethod]
        public void Vector4()
        {
            Assert.AreEqual("MZXW6===", Base32.Encode(AsciiEncoding.GetBytes("foo")));
        }

        [TestMethod]
        public void Vector5()
        {
            Assert.AreEqual("MZXW6YQ=", Base32.Encode(AsciiEncoding.GetBytes("foob")));
        }

        [TestMethod]
        public void Vector6()
        {
            Assert.AreEqual("MZXW6YTB", Base32.Encode(AsciiEncoding.GetBytes("fooba")));
        }

        [TestMethod]
        public void Vector7()
        {
            Assert.AreEqual("MZXW6YTBOI======", Base32.Encode(AsciiEncoding.GetBytes("foobar")));
        }
    }
}
