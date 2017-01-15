using MerchantsGuide.Contract;

namespace MerchantsGuide
{
    public class PreconditionExpression :
        Expression
    {
        public PreconditionExpressionType PreconditionType { get; set; }
    }
}