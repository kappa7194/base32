namespace Albireo.Base32.Tests
{
    using System.Text;

    public abstract class Base32Tests
    {
        protected static readonly Encoding AsciiEncoding = Encoding.GetEncoding(Encoding.ASCII.CodePage, EncoderFallback.ExceptionFallback, DecoderFallback.ExceptionFallback);
    }
}
