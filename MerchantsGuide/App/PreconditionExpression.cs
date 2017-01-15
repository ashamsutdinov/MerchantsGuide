using MerchantsGuide.App.Contract;

namespace MerchantsGuide.App
{
    public class PreconditionExpression :
        Expression
    {
        public PreconditionExpressionType PreconditionType { get; set; }
    }
}