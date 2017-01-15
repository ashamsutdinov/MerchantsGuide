using System.Collections.Generic;
using MerchantsGuide.App.Contract;

namespace MerchantsGuide.App
{
    public class RomanNumberParser :
        IRomanNumberParser
    {
        private readonly IDictionary<string, RomanDigit> _romanNumberSegments = new Dictionary<string, RomanDigit>
        {
            {"M", new RomanDigit(1000, 3)},
            {"CM", new RomanDigit(900,1)},
            {"D",new RomanDigit(500,1)},
            {"CD", new RomanDigit(400,1)},
            {"C", new RomanDigit(100,3)},
            {"XC", new RomanDigit(90,1)},
            {"L", new RomanDigit(50, 1)},
            {"XL", new RomanDigit(40, 1)},
            {"X", new RomanDigit(10, 3)},
            {"IX", new RomanDigit(9, 1)},
            {"V", new RomanDigit(5, 1)},
            {"IV", new RomanDigit(4, 1)},
            {"I", new RomanDigit(1, 3)}
        };

        public int Parse(string input)
        {
            var result = 0;
            foreach (var romanNum in _romanNumberSegments)
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


