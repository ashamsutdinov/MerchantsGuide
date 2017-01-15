using MerchantsGuide.Contract;

namespace MerchantsGuide
{
    public class Expression :
        IExpression
    {
        public ExpressionType Type { get; set; }

        public string Left { get; set; }

        public string Right { get; set; }
    }
}