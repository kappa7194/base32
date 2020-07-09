namespace Albireo.Base32.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DecodeTests : Base32Tests
    {
        [TestMethod]
        public void Vector1()
        {
            CollectionAssert.AreEqual(AsciiEncoding.GetBytes(string.Empty), Base32.Decode(string.Empty));
        }

        [TestMethod]
        public void Vector2()
        {
            CollectionAssert.AreEqual(AsciiEncoding.GetBytes("f"), Base32.Decode("MY======"));
        }

        [TestMethod]
        public void Vector3()
        {
            CollectionAssert.AreEqual(AsciiEncoding.GetBytes("fo"), Base32.Decode("MZXQ===="));
        }

        [TestMethod]
        public void Vector4()
        {
            CollectionAssert.AreEqual(AsciiEncoding.GetBytes("foo"), Base32.Decode("MZXW6==="));
        }

        [TestMethod]
        public void Vector5()
        {
            CollectionAssert.AreEqual(AsciiEncoding.GetBytes("foob"), Base32.Decode("MZXW6YQ="));
        }

        [TestMethod]
        public void Vector6()
        {
            CollectionAssert.AreEqual(AsciiEncoding.GetBytes("fooba"), Base32.Decode("MZXW6YTB"));
        }

        [TestMethod]
        public void Vector7()
        {
            CollectionAssert.AreEqual(AsciiEncoding.GetBytes("foobar"), Base32.Decode("MZXW6YTBOI======"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Vector7_Lowercase_BackwardsCompatibility()
        {
            CollectionAssert.AreEqual(AsciiEncoding.GetBytes("foobar"), Base32.Decode("mzxw6ytboi======"));
        }

        [TestMethod]
        public void Vector7_Lowercase()
        {
            CollectionAssert.AreEqual(AsciiEncoding.GetBytes("foobar"), Base32.Decode("mzxw6ytboi======", true));
        }
    }
}
