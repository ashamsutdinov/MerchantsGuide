namespace MerchantsGuide.App.Contract
{
    public interface IExpression
    {
        ExpressionType Type { get; }

        string Left { get; }

        string Right { get; }
    }
}