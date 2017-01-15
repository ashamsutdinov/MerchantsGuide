namespace MerchantsGuide.App.Contract
{
    public interface IExpressionProcessorFactory
    {
        IExpressionProcessor Get(string input);
    }
}