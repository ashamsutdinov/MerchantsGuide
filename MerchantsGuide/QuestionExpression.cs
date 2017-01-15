using MerchantsGuide.Contract;

namespace MerchantsGuide
{
    public class QuestionExpression : 
        Expression,
        IQuestionExpression
    {
        public QuestionExpressionType QuestionType { get; set; }
    }
}