namespace MerchantsGuide.App
{
    public class RomanDigit
    {
        public int DecimalValue { get; private set; }

        public int MaximumSequenceLength { get; private set; }

        public RomanDigit(int value, int maximumSequenceLength)
        {
            DecimalValue = value;
            MaximumSequenceLength = maximumSequenceLength;
        }
    }
}