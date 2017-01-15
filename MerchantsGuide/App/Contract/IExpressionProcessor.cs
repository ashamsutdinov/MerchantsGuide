namespace MerchantsGuide.App.Contract
{
    public interface IExpressionProcessor
    {
        void Process(string input, IProblemContext context);
    }
}