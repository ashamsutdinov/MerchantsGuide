using MerchantsGuide.Contract;

namespace MerchantsGuide
{
    public class Expression :
        IExpression
    {
        public ExpressionType Type { get; set; }
    }
}