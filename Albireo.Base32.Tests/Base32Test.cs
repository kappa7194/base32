namespace Albireo.Base32.Tests
{
    using System.Text;

    using Albireo.Base32;

    using Xunit;

    public class Base32Tests
    {
        private static readonly Encoding AsciiEncoding = Encoding.GetEncoding(Encoding.ASCII.CodePage, EncoderFallback.ExceptionFallback, DecoderFallback.ExceptionFallback);

        public class EncodeTests : Base32Tests
        {
            [Fact]
            public void Vector1()
            {
                Assert.Equal(string.Empty, Base32.Encode(AsciiEncoding.GetBytes(string.Empty)));
            }

            [Fact]
            public void Vector2()
            {
                Assert.Equal("MY======", Base32.Encode(AsciiEncoding.GetBytes("f")));
            }

            [Fact]
            public void Vector3()
            {
                Assert.Equal("MZXQ====", Base32.Encode(AsciiEncoding.GetBytes("fo")));
            }

            [Fact]
            public void Vector4()
            {
                Assert.Equal("MZXW6===", Base32.Encode(AsciiEncoding.GetBytes("foo")));
            }

            [Fact]
            public void Vector5()
            {
                Assert.Equal("MZXW6YQ=", Base32.Encode(AsciiEncoding.GetBytes("foob")));
            }

            [Fact]
            public void Vector6()
            {
                Assert.Equal("MZXW6YTB", Base32.Encode(AsciiEncoding.GetBytes("fooba")));
            }

            [Fact]
            public void Vector7()
            {
                Assert.Equal("MZXW6YTBOI======", Base32.Encode(AsciiEncoding.GetBytes("foobar")));
            }
        }

        public class DecodeTests : Base32Tests
        {
            [Fact]
            public void Vector1()
            {
                Assert.Equal(AsciiEncoding.GetBytes(string.Empty), Base32.Decode(string.Empty));
            }

            [Fact]
            public void Vector2()
            {
                Assert.Equal(AsciiEncoding.GetBytes("f"), Base32.Decode("MY======"));
            }

            [Fact]
            public void Vector3()
            {
                Assert.Equal(AsciiEncoding.GetBytes("fo"), Base32.Decode("MZXQ===="));
            }

            [Fact]
            public void Vector4()
            {
                Assert.Equal(AsciiEncoding.GetBytes("foo"), Base32.Decode("MZXW6==="));
            }

            [Fact]
            public void Vector5()
            {
                Assert.Equal(AsciiEncoding.GetBytes("foob"), Base32.Decode("MZXW6YQ="));
            }

            [Fact]
            public void Vector6()
            {
                Assert.Equal(AsciiEncoding.GetBytes("fooba"), Base32.Decode("MZXW6YTB"));
            }

            [Fact]
            public void Vector7()
            {
                Assert.Equal(AsciiEncoding.GetBytes("foobar"), Base32.Decode("MZXW6YTBOI======"));
            }
        }
    }
}
