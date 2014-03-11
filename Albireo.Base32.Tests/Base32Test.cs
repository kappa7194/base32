namespace Albireo.Base32.Tests
{
    using System;
    using System.Text;

    using Albireo.Base32;

    using Xunit;

    public class Base32Tests
    {
        private readonly Func<string, byte[]> getStringBytes = x => Encoding.ASCII.GetBytes(x);

        public class EncodeTests : Base32Tests
        {
            [Fact]
            public void Vector1()
            {
                Assert.Equal(string.Empty, Base32.Encode(getStringBytes(string.Empty)));
            }

            [Fact]
            public void Vector2()
            {
                Assert.Equal("MY======", Base32.Encode(getStringBytes("f")));
            }

            [Fact]
            public void Vector3()
            {
                Assert.Equal("MZXQ====", Base32.Encode(getStringBytes("fo")));
            }

            [Fact]
            public void Vector4()
            {
                Assert.Equal("MZXW6===", Base32.Encode(getStringBytes("foo")));
            }

            [Fact]
            public void Vector5()
            {
                Assert.Equal("MZXW6YQ=", Base32.Encode(getStringBytes("foob")));
            }

            [Fact]
            public void Vector6()
            {
                Assert.Equal("MZXW6YTB", Base32.Encode(getStringBytes("fooba")));
            }

            [Fact]
            public void Vector7()
            {
                Assert.Equal("MZXW6YTBOI======", Base32.Encode(getStringBytes("foobar")));
            }
        }
        public class DecodeTests : Base32Tests
        {
            [Fact]
            public void Vector1()
            {
                Assert.Equal(getStringBytes(string.Empty), Base32.Decode(string.Empty));
            }

            [Fact]
            public void Vector2()
            {
                Assert.Equal(getStringBytes("f"), Base32.Decode("MY======"));
            }

            [Fact]
            public void Vector3()
            {
                Assert.Equal(getStringBytes("fo"), Base32.Decode("MZXQ===="));
            }

            [Fact]
            public void Vector4()
            {
                Assert.Equal(getStringBytes("foo"), Base32.Decode("MZXW6==="));
            }

            [Fact]
            public void Vector5()
            {
                Assert.Equal(getStringBytes("foob"), Base32.Decode("MZXW6YQ="));
            }

            [Fact]
            public void Vector6()
            {
                Assert.Equal(getStringBytes("fooba"), Base32.Decode("MZXW6YTB"));
            }

            [Fact]
            public void Vector7()
            {
                Assert.Equal(getStringBytes("foobar"), Base32.Decode("MZXW6YTBOI======"));
            }
        }
    }
}
