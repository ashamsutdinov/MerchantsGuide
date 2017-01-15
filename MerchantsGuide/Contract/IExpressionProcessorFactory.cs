namespace MerchantsGuide.Contract
{
    public interface IExpressionProcessorFactory
    {
        IExpressionProcessor Get(string input);
    }
}