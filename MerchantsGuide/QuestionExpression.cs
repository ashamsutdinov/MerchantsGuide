using MerchantsGuide.Contract;

namespace MerchantsGuide
{
    public class QuestionExpression : 
        Expression
    {
        public QuestionExpressionType QuestionType { get; set; }

        public string SellResource { get; set; }

        public int SellAmount { get; set; }

        public string BuyResource { get; set; }

        public int BuyAmount { get; set; }
    }
}