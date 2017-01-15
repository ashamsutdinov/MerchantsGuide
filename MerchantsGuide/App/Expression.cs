using MerchantsGuide.App.Contract;

namespace MerchantsGuide.App
{
    public class Expression :
        IExpression
    {
        public ExpressionType Type { get; set; }

        public string Left { get; set; }

        public string Right { get; set; }
    }
}