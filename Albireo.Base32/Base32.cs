namespace Albireo.Base32
{
    using System;
    using System.Diagnostics.Contracts;

    public static class Base32
    {
        private const byte BitsInBlock = 5;
        private const byte BitsInByte = 8;
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";
        private const char Padding = '=';

        public static string Encode(byte[] input)
        {
            Contract.Requires<ArgumentException>(input != null);
            Contract.Ensures(Contract.Result<string>() != null);

            if (input.Length == 0)
            {
                return string.Empty;
            }

            var output = new char[(int) decimal.Ceiling((input.Length / (decimal) BitsInBlock)) * BitsInByte];
            var position = 0;
            byte workingByte = 0, remainingBits = BitsInBlock;

            foreach (var currentByte in input)
            {
                workingByte = (byte) (workingByte | (currentByte >> (BitsInByte - remainingBits)));
                output[position++] = Alphabet[workingByte];

                if (remainingBits < BitsInByte - BitsInBlock)
                {
                    workingByte = (byte) ((currentByte >> (BitsInByte - BitsInBlock - remainingBits)) & 31);
                    output[position++] = Alphabet[workingByte];
                    remainingBits += BitsInBlock;
                }

                remainingBits -= BitsInByte - BitsInBlock;
                workingByte = (byte) ((currentByte << remainingBits) & 31);
            }

            if (position != output.Length)
            {
                output[position++] = Alphabet[workingByte];
            }

            while (position < output.Length)
            {
                output[position++] = Padding;
            }

            return new string(output);
        }

        public static byte[] Decode(string input)
        {
            Contract.Requires<ArgumentNullException>(input != null);
            Contract.Requires<ArgumentException>(Contract.ForAll(input.ToCharArray(), x => Alphabet.IndexOf(x) >= 0 || x == Padding));
            Contract.Ensures(Contract.Result<byte[]>() != null);

            if (string.IsNullOrEmpty(input))
            {
                return new byte[0];
            }

            input = input.TrimEnd(Padding).ToUpperInvariant();

            var output = new byte[input.Length * BitsInBlock / BitsInByte];
            var position = 0;
            byte workingByte = 0, bitsRemaining = BitsInByte;

            foreach (var currentChar in input.ToCharArray())
            {
                int mask;
                var currentCharPosition = Alphabet.IndexOf(currentChar);

                if (bitsRemaining > BitsInBlock)
                {
                    mask = currentCharPosition << (bitsRemaining - BitsInBlock);
                    workingByte = (byte) (workingByte | mask);
                    bitsRemaining -= BitsInBlock;
                }
                else
                {
                    mask = currentCharPosition >> (BitsInBlock - bitsRemaining);
                    workingByte = (byte) (workingByte | mask);
                    output[position++] = workingByte;
                    workingByte = unchecked((byte) (currentCharPosition << (BitsInByte - BitsInBlock + bitsRemaining)));
                    bitsRemaining += BitsInByte - BitsInBlock;
                }
            }

            return output;
        }
    }
}
