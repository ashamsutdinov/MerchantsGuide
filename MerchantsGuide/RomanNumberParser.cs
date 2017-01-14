using System.Collections.Generic;

namespace MerchantsGuide
{
    public class RomanNumberParser
    {
        private static readonly IDictionary<string, RomanNumeral> RomanNumberSegments = new Dictionary<string, RomanNumeral>
        {
            {"M", new RomanNumeral(1000, 4)},
            {"CM", new RomanNumeral(900,1)},
            {"D",new RomanNumeral(500,1)},
            {"CD", new RomanNumeral(400,1)},
            {"C", new RomanNumeral(100,3)},
            {"XC", new RomanNumeral(90,1)},
            {"L", new RomanNumeral(50, 1)},
            {"XL", new RomanNumeral(40, 1)},
            {"X", new RomanNumeral(10, 3)},
            {"IX", new RomanNumeral(9, 1)},
            {"V", new RomanNumeral(5, 1)},
            {"IV", new RomanNumeral(4, 1)},
            {"I", new RomanNumeral(1, 3)}
        };

        public static int Parse(string input)
        {
            var result = 0;
            foreach (var romanNum in RomanNumberSegments)
            {
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                var sequenceLength = 0;
                while (input.StartsWith(romanNum.Key))
                {
                    if (sequenceLength >= romanNum.Value.MaximumSequenceLength)
                    {
                        //invalid number format
                        return -1;
                    }
                    result += romanNum.Value.DecimalValue;
                    input = input.Substring(romanNum.Key.Length);
                    sequenceLength++;
                }
            }

            if (!string.IsNullOrEmpty(input))
            {
                //invalid format
                return -1;
            }

            return result;
        }
    }
}


