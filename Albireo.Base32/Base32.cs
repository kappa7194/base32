﻿namespace Albireo.Base32
{
    using System;
    using System.Linq;

    public static class Base32
    {
        private const byte BitsInBlock = 5;
        private const byte BitsInByte = 8;
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";
        private const char Padding = '=';

        public static string Encode(in byte[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (input.Length == 0)
            {
                return string.Empty;
            }

            var output = new char[(int) decimal.Ceiling(input.Length / (decimal) BitsInBlock) * BitsInByte];
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

        public static byte[] Decode(in string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (string.IsNullOrEmpty(input))
            {
                return new byte[0];
            }

            var inputChars = input.TrimEnd(Padding).ToUpperInvariant().ToCharArray();

            if (inputChars.Any(x => Alphabet.IndexOf(x) == -1))
            {
                throw new ArgumentException(nameof(input));
            }

            var output = new byte[inputChars.Length * BitsInBlock / BitsInByte];
            var position = 0;
            byte workingByte = 0, bitsRemaining = BitsInByte;

            foreach (var currentChar in inputChars)
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
