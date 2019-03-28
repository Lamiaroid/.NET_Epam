using System;

namespace NET.S._2019.Tkachenko._03
{
    public static class DoubleExtension
    {
        /// <summary>
        /// Extension for double to get binary string representation of double value
        /// </summary>
        public static string GetBinaryStringRepresentation(this double number)
        {
            const int requiredBinaryStringLength = 64;
            const int requiredNumberBase = 2;

            // Get binary string representation of double without insignificant zeros
            string binaryRepresentation = Convert.ToString(BitConverter.DoubleToInt64Bits(number), requiredNumberBase);
            string extraZeros = "";

            // Get all insignificant zeros
            int binaryStringLength = binaryRepresentation.Length;
            while (binaryStringLength < requiredBinaryStringLength)
            {
                extraZeros += "0";
                binaryStringLength++;
            }

            return extraZeros + binaryRepresentation;
        }
    }
}
