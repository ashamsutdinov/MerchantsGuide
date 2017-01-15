namespace MerchantsGuide.Contract
{
    public interface IExpressionProcessor
    {
        IExpression Parse(string input, IProblemContext context);
    }
}