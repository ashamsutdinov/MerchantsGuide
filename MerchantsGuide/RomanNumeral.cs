namespace MerchantsGuide
{
    public class RomanNumeral
    {
        public int DecimalValue { get; private set; }

        public int MaximumSequenceLength { get; private set; }

        public RomanNumeral(int value, int maximumSequenceLength)
        {
            DecimalValue = value;
            MaximumSequenceLength = maximumSequenceLength;
        }
    }
}